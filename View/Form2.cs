using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3_tier_LINQ.DAL;

namespace _3_tier_LINQ.View
{
    public partial class Form2 : Form
    {

        public Svien_BLL bll { get; set; }
        public delegate void Add(SinhVien sv);
        public Add add;
        public void InItCBBQue()
        {
            cbbQue.DataSource = bll.GetComboQueQuan();
        }

        public void InItCBBKhoa()
        {
            cbbKhoa.DataSource = bll.GetComboKhoa();
        }
        public Form2()
        {   
            bll = new Svien_BLL();
            InitializeComponent();
            InItCBBKhoa();
            InItCBBQue();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV=Int32.Parse(textBoxMSSV.Text);
            sv.BrithDay = dateTimePicker1.Value;
            sv.DTH=Double.Parse(textBoxDTB.Text);
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
            add.Invoke(sv);
            MessageBox.Show("Done");
            Close();
        }

        private void buttonCan_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
