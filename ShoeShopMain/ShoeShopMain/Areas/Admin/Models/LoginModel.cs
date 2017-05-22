using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeShopMain.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Hãy nhập số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}