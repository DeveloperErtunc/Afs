using AFS.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Service.Helpers
{
    public class ResponseHelper
    {
        public static string IsSuccessMessage = "İşlem Başarılı";
        public static ResponseModel IsSuccess(string Message = "İşlem Başarılı", Object? data = null)
        {
            return new ResponseModel
            {
                IsSuccess = true,
                Message = Message,
                Data = data
            };
        }
        public static ResponseModel IsNotSuccess(string Message = "İşlem Başarısız", Object? data = null)
        {
            return new ResponseModel
            {
                IsSuccess = false,
                Message = Message,
                Data = data
            };
        }
    }
}
