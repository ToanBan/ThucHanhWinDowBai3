using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap3
{
    public partial class Input : Form
    {
        private static int currentStt = 0;
        public bool isEditMode = false;
        public Input()
        {
            InitializeComponent();
        }



        public delegate void DataSubmittedHandler(int stt, string id, string name, string gioitinh, double diem, string khoa);
        public event DataSubmittedHandler DataSubmitted;
        private void Input_Load(object sender, EventArgs e)
        {
            cmbKhoa.SelectedIndex = 1;
            radioNu.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentStt++;
            int stt = currentStt;
            string id = txtMa.Text;
            string name = txtName.Text;
            string khoa = cmbKhoa.SelectedItem.ToString();
            string gioitinh = radioNam.Checked ? "Nam" : "Nữ";

            double diem;
            if (!double.TryParse(txtDiem.Text, out diem))
            {
                return;
            }

            DataSubmitted?.Invoke(stt, id, name, gioitinh, diem, khoa);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        public void UpdateStudent(int stt, string id, string name, string gioitinh, double diem, string khoa)
        {
            isEditMode = true;
            currentStt = stt;
            txtMa.Text = id;
            txtName.Text = name;
            cmbKhoa.SelectedItem = khoa;
            if (gioitinh == "Nam")
            {
                radioNam.Checked = true;
            }
            else
            {
                radioNu.Checked = true;
            }
            txtDiem.Text = diem.ToString();

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = true ;
            DataSubmitted?.Invoke(currentStt, txtMa.Text, txtName.Text, radioNam.Checked ? "Nam" : "Nữ",
            double.Parse(txtDiem.Text),cmbKhoa.SelectedItem.ToString());    
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
