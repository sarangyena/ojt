using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using ZXing;
using ZXing.Aztec;


namespace prjPayroll
{
    public partial class frmScanner : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        public frmScanner()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[cbxCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmirror = (Bitmap)eventArgs.Frame.Clone();

            Mirror filter = new Mirror(false, true);
            filter.ApplyInPlace(bitmirror);

            pbScanner.Image = bitmirror;

        }

        private void frmScanner_Load(object sender, EventArgs e)
        {
            LoadAttendance();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo Device in CaptureDevice)
            {
                cbxCamera.Items.Add(Device.Name);
            }
            cbxCamera.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }
        private void LoadAttendance()
        {
            try
            {
                clsScannerM m = new clsScannerM();
                grdScanner.DataSource = m.GetAttendance().AsDataView();

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void frmScanner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pbScanner.Image);
            try
            {
                string decoded = result.ToString().Trim();
                if(decoded != "")
                {
                    txtMessage.Text = decoded;
                    clsScanner s = new clsScanner();
                    s.userId = decoded;
                    clsScannerM m = new clsScannerM();
                    m.GetDetails(s);
                    if(m.userAttendance(s) == true)
                    {
                        timer1.Stop();
                        DialogResult r = MessageBox.Show("Success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(r == DialogResult.OK)
                        {
                            timer1.Start();
                            grdScanner.DataSource = m.GetAttendance().AsDataView();
                        }
                    }
                    else
                    {
                        timer1.Stop();
                        DialogResult r = MessageBox.Show("Error.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (r == DialogResult.OK)
                        {
                            timer1.Start();
                            grdScanner.DataSource = m.GetAttendance().AsDataView();
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Start Scanning.", "QR Scanner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();
        }
    }
}
