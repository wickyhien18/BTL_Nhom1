using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL___Nhóm_1.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } = "Sinh viên";
    }
}
