using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_tier_LINQ;
using _3_tier_LINQ.DAL;

namespace _3_tier_LINQ
{
    public class Svien_DAL
    {
        public StudentManagerDataContext db = new StudentManagerDataContext();
        public Svien_DAL()
        {
            db = new StudentManagerDataContext();
        }

        public List<string> GetCBBkhoa()
        {
            List<string> list = new List<string>();
            var s = db.Khoas.Select(p => new {p.TenKhoa}).Distinct();
            foreach (var i in s)
            {
                list.Add(i.TenKhoa.Trim());
            }
            return list;
        }

        public List<string> GetCBBque()
        {
            List<string> list = new List<string>();
            var s = db.SinhViens.Select(p => new { p.QueQuan }).Distinct();
            foreach (var i in s)
            {
                list.Add(i.QueQuan.Trim());
            }
            return list;
        }
        public IEnumerable<object> GetListSinhVien()
        {
            IEnumerable<object> list = db.SinhViens.Join(db.Khoas, p => p.ID_Khoa, k => k.ID_Khoa,
                (p, k) => new
                {
                    p.MSSV,
                    p.Name,
                    p.BrithDay,
                    p.Gender,
                    p.HoKhau,
                    p.Khoa.ID_Khoa,
                    p.DTH,
                    p.QueQuan
                });
            return list;

        }

        public void Add(SinhVien sv)
        {
            db.SinhViens.InsertOnSubmit(sv);
            db.SubmitChanges();
        }

        public SinhVien getSV(int  mssv)
        {
            var s = db.SinhViens.Single(p => p.MSSV == mssv);
            return s;
        }
        public void Del(int mssv)
        {
            SinhVien s = getSV(mssv);
            db.SinhViens.DeleteOnSubmit(s);
            db.SubmitChanges(); 
        }

        public void Update(SinhVien sv)
        {
            SinhVien s = getSV(sv.MSSV);
            s.Name = sv.Name;
            s.BrithDay = sv.BrithDay;
            s.Gender = sv.Gender;
            s.DTH = sv.DTH;
            s.HoKhau = sv.HoKhau;
            s.ID_Khoa = sv.ID_Khoa;
            s.QueQuan = sv.QueQuan;
            db.SubmitChanges();
        }
        public IEnumerable<object> Search(string name)
        {
            IEnumerable<object> list = db.SinhViens.Join(db.SinhViens, p => p.ID_Khoa, k => k.Khoa.ID_Khoa,
                (p, k) => new
                {
                    p.MSSV,
                    p.Name,
                    p.BrithDay,
                    p.Gender,
                    p.HoKhau,
                    p.Khoa.ID_Khoa,
                    p.DTH,
                    p.QueQuan
                }).Where(p => p.Name.Contains(name)).Distinct();
            return list;
        }
    }
}
