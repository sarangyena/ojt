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
using Telerik.WinControls.UI;

namespace VJOMS
{
    public partial class frmDashboard : Form
    {
        private Int64 vId;
        private String vPlate;
        private List<RadTextBox> radTextBoxes;
        private bool edit;
        public string jono { get; set; }

        public frmDashboard()
        {
            InitializeComponent();
            radTextBoxes = new List<RadTextBox>();
            edit = false;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            radTextBoxes.AddRange(twDetails.Controls.OfType<RadTextBox>());
            grdJOList.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdModel.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            LoadModel();
        }
        private void LoadModel()
        {
            try
            {
                clsModelM m = new clsModelM();
                grdModel.DataSource = m.getAllModel().AsDataView();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadJO()
        {
            try
            {
                clsModel m = new clsModel();
                m.vId = vId;
                m.plate = vPlate;
                clsModelM dv = new clsModelM();
                grdJOList.DataSource = dv.getJOListById(m);
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MasterTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                vId = Convert.ToInt64(grdModel.SelectedRows[0].Cells["VID"].Value.ToString());
                vPlate = grdModel.SelectedRows[0].Cells["VPLATE"].Value.ToString();
                clsModel b = new clsModel();
                b.vId = vId;
                b.plate = vPlate;
                LoadJO();
                clsModelM dv = new clsModelM();
                dv.getModelById(b);
                txtBrand.Text = b.brand;
                txtModel.Text = b.model;
                txtYear.Text = b.year.ToString();
                txtColor.Text = b.color;
                txtPlate.Text = b.plate;
                txtCompany.Text = b.company;
                txtAssigned.Text = b.assigned;
                txtOwner.Text = b.owner;
                txtStatus.Text = b.status;
                txtRemarks.Text = b.remarks;
                txtRegistration.Text = b.registration;

                foreach (RadTextBox radTextBox in radTextBoxes)
                {
                    radTextBox.ReadOnly = true;
                }

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Model", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void clear()
        {
            // Clear the Text property of each RadTextBox
            foreach (RadTextBox radTextBox in radTextBoxes)
            {
                radTextBox.Text = string.Empty;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            foreach (RadTextBox radTextBox in radTextBoxes)
            {
                radTextBox.ReadOnly = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsModelM md = new clsModelM();
            clsModel m = new clsModel();
            if (edit == true)
            {
                try
                {
                    m.vId = Convert.ToInt64(grdModel.SelectedRows[0].Cells["VID"].Value.ToString());
                    m.brand = txtBrand.Text;
                    m.model = txtModel.Text;
                    m.year = Convert.ToInt64(txtYear.Text);
                    m.color = txtColor.Text;
                    m.plate = txtPlate.Text;
                    m.company = txtCompany.Text;
                    m.assigned = txtAssigned.Text;
                    m.owner = txtOwner.Text;
                    m.status = txtStatus.Text;
                    m.remarks = txtRemarks.Text;
                    m.registration = txtRegistration.Text;
                    md.editModel(m);
                    foreach (RadTextBox radTextBox in radTextBoxes)
                    {
                        radTextBox.ReadOnly = true;
                        radTextBox.Clear();
                    }
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    grdModel.DataSource = md.getAllModel();
                    edit = false;
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if(edit == false)
            {
                try
                {
                    m.vId = md.getMaxId() + 1;
                    m.brand = txtBrand.Text;
                    m.model = txtModel.Text;
                    m.year = Convert.ToInt64(txtYear.Text);
                    m.color = txtColor.Text;
                    m.plate = txtPlate.Text;
                    m.company = txtCompany.Text;
                    m.assigned = txtAssigned.Text;
                    m.owner = txtOwner.Text;
                    m.status = txtStatus.Text;
                    m.remarks = txtRemarks.Text;
                    m.registration = txtRegistration.Text;
                    clsModelM dv = new clsModelM();
                    dv.addModel(m);
                    foreach (RadTextBox radTextBox in radTextBoxes)
                    {
                        radTextBox.ReadOnly = true;
                        radTextBox.Clear();
                    }
                    btnAdd.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    grdModel.DataSource = dv.getAllModel();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clsModelM m = new clsModelM();
            clsModel md = new clsModel();
            md.plate = vPlate;
            m.statusInactive(md);
            grdModel.DataSource = m.getAllModel();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            try
            {
                if (vId == 0)
                {
                    MessageBox.Show("No data selected.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }else
                {
                    foreach (RadTextBox radTextBox in radTextBoxes)
                    {
                        edit = true;
                        radTextBox.ReadOnly = false;
                    }
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void grdModel_DoubleClick(object sender, EventArgs e)
        {
            vId = Convert.ToInt64(grdModel.SelectedRows[0].Cells["VID"].Value.ToString());
            clsModel b = new clsModel();
            b.vId = vId;
            clsModelM dv = new clsModelM();
            dv.getModelById(b);
            frmaddJO frm = new frmaddJO(this);
            frm.plate = b.plate;
            frm.model = b.model;
            frm.year = b.year.ToString();
            frm.company = b.company;
            frm.brand = b.brand;
            frm.user = b.assigned;
            frm.JONo = dv.getMaxIdJO()+1;
            frm.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Keys press = e.KeyCode;
            string word = txtSearch.Text;
            MessageBox.Show(word);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                foreach (GridViewRowInfo row in grdModel.Rows)
                {
                    bool rowMatchesSearchTerm = false;

                    foreach (GridViewCellInfo cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            rowMatchesSearchTerm = true;
                            break;
                        }
                    }
                    row.IsVisible = rowMatchesSearchTerm;
                }
            }
        }

        private void grdJOList_DoubleClick(object sender, EventArgs e)
        {
            jono = grdJOList.SelectedRows[0].Cells["JONO"].Value.ToString();
            frmJOReport frm = new frmJOReport();
            frm.jono = jono;
            frm.ShowDialog();
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
