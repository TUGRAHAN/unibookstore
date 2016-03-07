using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniBookStore.Areas.Admin.Models.Dto
{
    public class AdminRegisterJsonResponse // bu class icerisinde girisin sonuclarini yaziyoruz
    {
        public string Message { get; set; }
        public string Class { get; set; }
        public bool isSuccess { get; set; }
    }
}