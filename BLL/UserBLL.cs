using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public List<UserDTO> LayDanhSachUser()
        {
            return userDAL.LayDanhSachUser();
        }

        public string ThemUser(UserDTO user)
        {
            // 1. Kiểm tra trống
            if (string.IsNullOrWhiteSpace(user.TenDangNhap) || string.IsNullOrWhiteSpace(user.MatKhau))
                return "Tên đăng nhập và mật khẩu không được để trống.";

            // 2. Kiểm tra viết hoa toàn bộ
            if (user.TenDangNhap != user.TenDangNhap.ToUpper())
                return "Mã đăng nhập phải viết hoa toàn bộ.";

            // 3. Kiểm tra tiền tố và gán vai trò
            if (!GanVaiTroTheoTienTo(user))
                return "Mã người dùng không hợp lệ. Kí tự đầu phải là CT, CD, CB, TT hoặc NTT.";

            // 4. Kiểm tra mật khẩu hợp lệ
            if (!KiemTraMatKhauHopLe(user.MatKhau))
                return "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ, số và ký tự đặc biệt.";

            // 5. Kiểm tra tồn tại tên đăng nhập trong bảng liên quan
            if (!userDAL.KiemTraTenDangNhapTonTai(user.TenDangNhap))
                return "Tên đăng nhập không tồn tại.";

            // 6. Gọi DAL thêm
            bool ketQua = userDAL.ThemUser(user);
            return ketQua ? "Đăng Ký Thành Công!." : "Đăng Ký Thất bại.";
        }

        public string SuaUser(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.TenDangNhap) || string.IsNullOrWhiteSpace(user.MatKhau))
                return "Tên đăng nhập và mật khẩu không được để trống.";

            if (user.TenDangNhap != user.TenDangNhap.ToUpper())
                return "Mã đăng nhập phải viết hoa toàn bộ.";

            if (!GanVaiTroTheoTienTo(user))
                return "Mã người dùng không hợp lệ. Kí tự đầu phải là CT, CD, CB, TT hoặc NTT.";

            if (!KiemTraMatKhauHopLe(user.MatKhau))
                return "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ, số và ký tự đặc biệt.";

            if (!userDAL.KiemTraTenDangNhapTonTai(user.TenDangNhap))
                return "Tên đăng nhập không tồn tại.";

            bool ketQua = userDAL.SuaUser(user);
            return ketQua ? "Sửa user thành công!" : "Sửa user thất bại.";
        }

        public string XoaUser(string maUser)
        {
            bool ketQua = userDAL.XoaUser(maUser);
            return ketQua ? "Xóa tài khoản người dùng thành công!" : "Xóa thất bại.";
        }

        public List<UserDTO> TimKiemUser(string TenDangNhap)
        {
            return userDAL.TimKiemUser(TenDangNhap);
        }

        public UserDTO DangNhap(string tenDangNhap, string matKhau)
        {
            var danhSach = userDAL.LayDanhSachUser();
            return danhSach.FirstOrDefault(u => u.TenDangNhap == tenDangNhap && u.MatKhau == matKhau);
        }

        private bool KiemTraMatKhauHopLe(string matKhau)
        {
            if (matKhau.Length < 8) return false;

            bool coChu = false, coSo = false, coKyTuDacBiet = false;

            foreach (char c in matKhau)
            {
                if (char.IsLetter(c)) coChu = true;
                else if (char.IsDigit(c)) coSo = true;
                else if (!char.IsLetterOrDigit(c)) coKyTuDacBiet = true;
            }

            return coChu && coSo && coKyTuDacBiet;
        }

        private bool GanVaiTroTheoTienTo(UserDTO user)
        {
            if (user.TenDangNhap.StartsWith("CD"))
                user.VaiTro = "Cư dân";
            else if (user.TenDangNhap.StartsWith("CT"))
                user.VaiTro = "Chủ trọ";
            else if (user.TenDangNhap.StartsWith("CB"))
                user.VaiTro = "Cán bộ";
            else if (user.TenDangNhap.StartsWith("TT"))
                user.VaiTro = "Trưởng thôn";
            else if (user.TenDangNhap.StartsWith("NTT"))
                user.VaiTro = "Tạm trú";
            else
                return false;
            return true;
        }
    }
}

