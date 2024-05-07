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
    public partial class frmaddJO : Form
    {
        private List<RadTextBox> radTextBoxes;
        private List<RadLabel> radLabels;
        private List<RadButton> radButtons;

        public Int64 JONo { get; set; }
        public string plate { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string company { get; set; }
        public string brand { get; set; }
        public string user { get; set; }

        private string name;
        private decimal discount;
        private string details;
        private decimal amount;
        private string accom;
        private decimal sub;

        private string regDetails;
        private decimal regAmount;
        private decimal regTotal;

        private DataTable dataTable;
        private DataTable dataTable1;


        private readonly frmDashboard frm1;
        public frmaddJO(frmDashboard frm)
        {
            InitializeComponent();
            frm1 = frm;

            radTextBoxes = new List<RadTextBox>();
            radLabels = new List<RadLabel>();
            radButtons = new List<RadButton>();
            dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("discount", typeof(decimal));
            dataTable.Columns.Add("details", typeof(string));
            dataTable.Columns.Add("amount", typeof(decimal));
            dataTable.Columns.Add("accom", typeof(string));
            dataTable1 = new DataTable();
            dataTable1.Columns.Add("details", typeof(string));
            dataTable1.Columns.Add("amount", typeof(decimal));

            amount = 0;
            discount = 0;
        }
        public static void decimalParse(RadTextBox textBox)
        {

            decimal value;
            if (decimal.TryParse(textBox.Text, out value))
            {
                textBox.Text = value.ToString("0.00");
            }
        }
        public static void decimalKeypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as RadTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public static void nullText(RadTextBox textbox)
        {
            if (textbox.Text == "" && textbox.Name != "txtAccom")
            {
                textbox.Text = "0.00";
            }else if(textbox.Name == "txtAccom")
            {
                textbox.Text = "100% DONE";
            }
        }
        public void resetField()
        {
            btnAdd.Enabled = true;
            btnAdd.Visible = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = true;
            btnDelete.Enabled = false;
            btnDelete.Visible = true;
            txtAccom.ReadOnly = false;
            txtDiscount.ReadOnly = false;
            txtName.Clear();
            txtDetails.Clear();
            txtAmount.Clear();
            txtAccom.Clear();
            txtDiscount.Clear();
        }
        private void cbRegistration_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(cbRegistration.Checked == true)
            {
                grdRegistration.Enabled = true;
                foreach (RadTextBox radTextBox in radTextBoxes)
                {
                    if(radTextBox.Name == "txtRegDetails" || radTextBox.Name == "txtRegAmount" || radTextBox.Name == "txtRegTotal")
                    {
                        radTextBox.ReadOnly = false;
                    }
                    radTextBox.Enabled = true;
                }
                foreach (RadLabel radLabel in radLabels)
                {
                    radLabel.Enabled = true;
                }
                foreach (RadButton radButton in radButtons)
                {
                    radButton.Enabled = true;
                }
            }
            else
            {
                grdRegistration.Enabled = false;
                foreach (RadTextBox radTextBox in radTextBoxes)
                {
                    if (radTextBox.Name == "txtRegDetails" || radTextBox.Name == "txtRegAmount" || radTextBox.Name == "txtRegTotal")
                    {
                        radTextBox.Enabled = false;
                    }
                    else
                    {
                        radTextBox.Enabled = true;

                    }
                }
                foreach (RadLabel radLabel in radLabels)
                {
                    radLabel.Enabled = false;
                }
                foreach (RadButton radButton in radButtons)
                {
                    radButton.Enabled = false;
                }
            }
            

        }

        private void frmaddJO_Load(object sender, EventArgs e)
        {
            grdJO.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            grdRegistration.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            txtJO.Text = JONo.ToString();
            DateTime today = DateTime.Today;
            lblDate.Text = today.ToShortDateString();
            radTextBoxes.AddRange(radPanel4.Controls.OfType<RadTextBox>());
            radLabels.AddRange(radPanel4.Controls.OfType<RadLabel>());
            radLabels.AddRange(splitPanel4.Controls.OfType<RadLabel>());
            radTextBoxes.AddRange(splitPanel4.Controls.OfType<RadTextBox>());
            radButtons.AddRange(splitPanel4.Controls.OfType<RadButton>());
            radTextBoxes.AddRange(dwProfile.Controls.OfType<RadTextBox>());

            txtPlate.Text = plate;
            txtBrand.Text = brand;
            txtCompany.Text = company;
            txtUser.Text = user;
            txtModel.Text = model;
            txtYear.Text = year;
            foreach (RadTextBox radTextBox in radTextBoxes)
            {
                if(radTextBox.Name != "txtUser")
                {
                    radTextBox.ReadOnly = true;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDetails.Clear();
            txtAmount.Clear();
            txtAccom.Clear();
            txtDiscount.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                nullText(txtDiscount);
                nullText(txtAccom);
                name = txtName.Text;
                discount = Convert.ToDecimal(txtDiscount.Text);
                details = txtDetails.Text;
                amount = Convert.ToDecimal(txtAmount.Text);
                accom = txtAccom.Text;
                dataTable.Rows.Add(name, discount, details, amount, accom);
                grdJO.DataSource = dataTable;
                txtName.Clear();
                txtDetails.Clear();
                txtAmount.Clear();
                txtDiscount.Clear();
                txtAccom.Clear();
                sub = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                discount = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
                }
                txtSub.Text = sub.ToString();
                txtTotal.Text = (sub - discount).ToString();
                MessageBox.Show("Successfully added details.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception err)
            {
                txtAccom.Clear();
                txtDiscount.Clear();
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtSub.ReadOnly = true;
                txtTotal.ReadOnly = true;
                txtName.Text = grdJO.SelectedRows[0].Cells["name"].Value.ToString();
                txtDetails.Text = grdJO.SelectedRows[0].Cells["details"].Value.ToString();
                txtAmount.Text = grdJO.SelectedRows[0].Cells["amount"].Value.ToString();
                txtAccom.Text = grdJO.SelectedRows[0].Cells["accom"].Value.ToString();
                txtDiscount.Text = grdJO.SelectedRows[0].Cells["discount"].Value.ToString();
                sub = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                discount = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
                }
                txtSub.Text = sub.ToString();
                txtTotal.Text = (sub - discount).ToString();
            }
            catch(Exception err)
            {
                MessageBox.Show("Please select a detail to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimalKeypress(sender, e);
        }

        private void txtPrevAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimalKeypress(sender, e);
        }

        private void txtPrevTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimalKeypress(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            grdJO.Rows.Remove(grdJO.SelectedRows[0]);
            MessageBox.Show("Successfully remove.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sub = 0;
            foreach (GridViewRowInfo row in grdJO.Rows)
            {
                sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
            }
            discount = 0;
            foreach (GridViewRowInfo row in grdJO.Rows)
            {
                discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
            }
            txtSub.Text = sub.ToString();
            txtTotal.Text = (sub - discount).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sub = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                discount = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
                }
                //JOLIST
                clsDetails d = new clsDetails();
                clsDetailsM dm = new clsDetailsM();
                d.JONo = Convert.ToInt64(txtJO.Text);
                d.plate = txtPlate.Text;
                d.model = txtModel.Text;
                d.year = Convert.ToInt64(txtYear.Text);
                d.company = txtCompany.Text;
                d.brand = txtBrand.Text;
                d.user = txtUser.Text;
                d.total = sub - discount;
                d.sub = sub;
                d.less = discount;
                d.max = d.JONo;
                dm.addJO(d);

                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    d.name = row.Cells["name"].Value.ToString();
                    d.details = row.Cells["details"].Value.ToString();
                    d.amount = Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                    d.total = sub;
                    d.accomplishment = row.Cells["accom"].Value.ToString();
                    dm.addDetails(d);
                }

                if (cbRegistration.Checked)
                {
                    regTotal = 0;
                    foreach (GridViewRowInfo row in grdRegistration.Rows)
                    {
                        regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                    }
                    foreach (GridViewRowInfo row in grdRegistration.Rows)
                    {
                        d.details = row.Cells["details"].Value.ToString();
                        d.amount = Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                        d.total = regTotal;
                        dm.addPrev(d);
                    }
                }
                MessageBox.Show("Successfully added.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm1.LoadJO();
                this.Hide();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            decimalParse(txtAmount);
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            decimalParse(txtTotal);
        }


        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimalKeypress(sender, e);
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            decimalParse(txtDiscount);
        }

        private void txtSub_TextChanged(object sender, EventArgs e)
        {
            decimalParse(txtSub);
        }

        private void MasterTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtAccom.ReadOnly = true;
                txtDiscount.ReadOnly = true;
                sub = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                discount = 0;
                foreach (GridViewRowInfo row in grdJO.Rows)
                {
                    discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
                }
                txtName.Text = grdJO.SelectedRows[0].Cells["name"].Value.ToString();
                txtDetails.Text = grdJO.SelectedRows[0].Cells["details"].Value.ToString();
                txtAmount.Text = grdJO.SelectedRows[0].Cells["amount"].Value.ToString();
                txtAccom.Text = grdJO.SelectedRows[0].Cells["accom"].Value.ToString();
                txtSub.Text = sub.ToString();
                txtDiscount.Text = grdJO.SelectedRows[0].Cells["discount"].Value.ToString();
                txtTotal.Text = (Convert.ToDecimal(txtSub.Text) - discount).ToString();
            }
            catch(Exception err)
            {
                MessageBox.Show("Please add details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtAccom.ReadOnly = false;
                txtDiscount.ReadOnly = false;
            }
            

        }

        private void btnSaveD_Click(object sender, EventArgs e)
        {
            grdJO.SelectedRows[0].Cells["name"].Value = txtName.Text;
            grdJO.SelectedRows[0].Cells["details"].Value = txtDetails.Text;
            grdJO.SelectedRows[0].Cells["amount"].Value = txtAmount.Text;
            grdJO.SelectedRows[0].Cells["accom"].Value = txtAccom.Text;
            grdJO.SelectedRows[0].Cells["discount"].Value = txtDiscount.Text;
            sub = 0;
            foreach (GridViewRowInfo row in grdJO.Rows)
            {
                sub += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
            }
            discount = 0;
            foreach (GridViewRowInfo row in grdJO.Rows)
            {
                discount += Convert.ToDecimal(row.Cells["discount"].Value.ToString());
            }
            txtSub.Text = sub.ToString();
            txtTotal.Text = (Convert.ToDecimal(txtSub.Text) - discount).ToString();
            MessageBox.Show("Successfully saved details.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resetField();
        }

        private void grdJO_Leave(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            txtAccom.ReadOnly = false;
            txtDiscount.ReadOnly = false;
            txtName.Clear();
            txtDetails.Clear();
            txtAmount.Clear();
            txtAccom.Clear();
            txtSub.Clear();
            txtDiscount.Clear();
            txtTotal.Clear();
        }

        private void btnCancelD_Click(object sender, EventArgs e)
        {
            resetField();
        }

        private void txtRegAmount_Leave(object sender, EventArgs e)
        {
            decimalParse(txtRegAmount);
        }

        private void grdRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                btnRegAdd.Enabled = false;
                btnRegEdit.Enabled = true;
                btnRegDel.Enabled = true;
                txtRegDetails.Text = grdRegistration.SelectedRows[0].Cells["details"].Value.ToString();
                txtRegAmount.Text = grdRegistration.SelectedRows[0].Cells["amount"].Value.ToString();
                regTotal = 0;
                foreach (GridViewRowInfo row in grdRegistration.Rows)
                {
                    regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                txtRegTotal.Text = regTotal.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Please add details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegAdd.Enabled = true;
                btnRegEdit.Enabled = false;
                btnRegDel.Enabled = false;
            }
        }

        private void btnRegAdd_Click(object sender, EventArgs e)
        {
            try
            {
                regDetails = txtRegDetails.Text;
                regAmount = Convert.ToDecimal(txtRegAmount.Text);
                dataTable1.Rows.Add(regDetails, regAmount);
                grdRegistration.DataSource = dataTable1;
                txtRegDetails.Clear();
                txtRegAmount.Clear();
                regTotal = 0;
                foreach (GridViewRowInfo row in grdRegistration.Rows)
                {
                    regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                txtRegTotal.Text = regTotal.ToString();
                MessageBox.Show("Successfully added details.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnRegAdd.Enabled = false;
                btnRegEdit.Visible = false;
                btnRegDel.Visible = false;
                txtRegDetails.Text = grdRegistration.SelectedRows[0].Cells["details"].Value.ToString();
                txtRegAmount.Text = grdRegistration.SelectedRows[0].Cells["amount"].Value.ToString();
                regTotal = 0;
                foreach (GridViewRowInfo row in grdRegistration.Rows)
                {
                    regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
                }
                txtRegTotal.Text = regTotal.ToString();
            }
            catch(Exception err)
            {
                MessageBox.Show("Please select a detail to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegDel_Click(object sender, EventArgs e)
        {
            grdRegistration.Rows.Remove(grdJO.SelectedRows[0]);
            MessageBox.Show("Successfully remove.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            regTotal = 0;
            foreach (GridViewRowInfo row in grdRegistration.Rows)
            {
                regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
            }
            txtRegTotal.Text = regTotal.ToString();
        }

        private void btnRegSave_Click(object sender, EventArgs e)
        {
            grdRegistration.SelectedRows[0].Cells["details"].Value = txtRegDetails.Text;
            grdRegistration.SelectedRows[0].Cells["amount"].Value = txtRegAmount.Text;
            regTotal = 0;
            foreach (GridViewRowInfo row in grdRegistration.Rows)
            {
                regTotal += Convert.ToDecimal(row.Cells["amount"].Value.ToString());
            }
            txtRegTotal.Text = regTotal.ToString();
            MessageBox.Show("Successfully saved details.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtRegDetails.Clear();
            txtRegAmount.Clear();
            btnRegAdd.Enabled = true;
            btnRegEdit.Visible = true;
            btnRegEdit.Enabled = false;
            btnRegDel.Visible = true;
            btnRegDel.Enabled = false;
        }

        private void btnRegCancel_Click(object sender, EventArgs e)
        {
            txtRegDetails.Clear();
            txtRegAmount.Clear();
            btnRegAdd.Enabled = true;
            btnRegEdit.Visible = true;
            btnRegEdit.Enabled = false;
            btnRegDel.Visible = true;
            btnRegDel.Enabled = false;
        }
    }
}
