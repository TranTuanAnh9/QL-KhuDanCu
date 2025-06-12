using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class CurrentUser
    {
        public static int MaUser { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
    }
}
