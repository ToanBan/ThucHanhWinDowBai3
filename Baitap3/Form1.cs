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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                Input frm = new Input();
                frm.ShowDialog();
            }

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Input frmInput = new Input();
            frmInput.DataSubmitted += OnDataSubmitted;
            frmInput.ShowDialog();
        }


        private void OnDataSubmitted(int stt, string id, string name, string gioitinh, double diem, string khoa)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                selectedRow.Cells["colStt"].Value = stt - 1;
                selectedRow.Cells["colMa"].Value = id;
                selectedRow.Cells["colName"].Value = name;
                selectedRow.Cells["colGioitinh"].Value = gioitinh;
                selectedRow.Cells["colDiem"].Value = diem;
                selectedRow.Cells["colKhoa"].Value = khoa;
            }
            else
            {
                dataGridView1.Rows.Add(stt, id, name, gioitinh, diem, khoa);
            }
            UpdateGenderCounts();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
            }
            else
            {
                e.Cancel = true;    
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGenderCounts();
            toolStripTextBox1.TextChanged += ToolStripTextBox1_TextChanged;
        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = toolStripTextBox1.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        match = true; 
                        break; 
                    }
                }
                row.Visible = match;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UpdateGenderCounts()
        {
            int maleCount = 0;
            int femaleCount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; 

                var genderCell = row.Cells["colGioitinh"].Value;
                if (genderCell != null)
                {
                    string gender = genderCell.ToString();
                    if (gender.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                    {
                        maleCount++;
                    }
                    else if (gender.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                    {
                        femaleCount++;
                    }
                }
            }
            toolStripLabel2.Text = maleCount.ToString();
            toolStripLabel4.Text = femaleCount.ToString();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
