using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_tier_LINQ;
using _3_tier_LINQ.DAL;

namespace _3_tier_LINQ
{
    public class Svien_BLL
    {
        public Svien_DAL dal { get; set; }

        public Svien_BLL()
        {
            dal = new Svien_DAL();
        }
        public List<string> GetComboKhoa()
        {
            return dal.GetCBBkhoa();
        }

        public List<string> GetComboQueQuan()
        {
            return dal.GetCBBque();
        }

        public IEnumerable<object> GetListSinhVien()
        {
            return dal.GetListSinhVien();
        }

        public void Add_SinhVien(SinhVien sv)
        {
            dal.Add(sv);
        }

        public SinhVien GetSinhVien(int mssv)
        {
            return dal.getSV(mssv);
        }

        public void Del_SinhVien(int mssv)
        {
            dal.Del(mssv);
        }

        public void Update_SinhVien(SinhVien sv)
        {
            dal.Update(sv);
        }

        public IEnumerable<object> Search_SinhVien(string ten)
        {
            return dal.Search(ten);
        }
    }
}
