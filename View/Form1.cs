using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3_tier_LINQ;
using _3_tier_LINQ.DAL;
using _3_tier_LINQ.View;

namespace _3_tier_LINQ
{
    public partial class Form1 : Form
    {
        public Svien_BLL bll { get; set; }
        public Form1()
        {
            bll = new Svien_BLL();
            InitializeComponent();
            InItCBBKhoa();
            InItCBBQue();
        }

        public void InItCBBQue()
        {
            cbbQue.DataSource = bll.GetComboQueQuan();
        }

        public void InItCBBKhoa()
        {
            cbbKhoa.DataSource = bll.GetComboKhoa();
        }

        public void buttonShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.GetListSinhVien();
        }

        private void ADD_SV(SinhVien sv)
        {
            bll.Add_SinhVien(sv);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.add= ADD_SV;
            f.Show();
        }

        public void getOnClick(SinhVien sv)
        {
            textBoxMSSV.Text = sv.MSSV.ToString();
            textBoxTen.Text = sv.Name;
            textBoxHK.Text = sv.HoKhau;
            textBoxDTB.Text = sv.DTH.ToString();
            dateTimePicker1.Value = sv.BrithDay.Value;
            cbbKhoa.SelectedIndex = cbbKhoa.FindStringExact(sv.Khoa.TenKhoa.Trim());
            cbbQue.SelectedIndex = cbbQue.FindStringExact(sv.QueQuan.Trim());
            if (sv.Gender.Equals(true))
            {
                radioNam.Checked = true;
            }
            else radioNu.Checked = true;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = Int32.Parse(textBoxMSSV.Text);
            sv.BrithDay = dateTimePicker1.Value;
            sv.DTH = Double.Parse(textBoxDTB.Text);
            sv.HoKhau = textBoxHK.Text;
            sv.ID_Khoa = cbbKhoa.SelectedIndex;
            sv.QueQuan = cbbQue.SelectedText;
            sv.Name = textBoxTen.Text;
            if (radioNam.Checked)
            {
                sv.Gender = true;
            }
            else
            {
                sv.Gender = false;
            }
            bll.Update_SinhVien(sv);
            dataGridView1.DataSource = bll.GetListSinhVien();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int maSV = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            bll.Del_SinhVien(maSV);
            MessageBox.Show("Done");
            dataGridView1.DataSource = bll.GetListSinhVien();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll.Search_SinhVien(textBoxSearch.Text);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Notthing");
            }
            else
            {
                int maSV = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
             
                getOnClick(bll.GetSinhVien(maSV));
            }
        }
    }
}
