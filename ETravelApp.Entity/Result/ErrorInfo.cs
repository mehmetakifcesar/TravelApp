using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.Result
{
    public class ErrorInfo
    {
        public string ErrorDescription { get; set; }
        public object Errors { get; set; }

        public static ErrorInfo NotFound(string errorDescription = "Sonuç Bulunamadı", object errors = null)
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };

        }

        public static ErrorInfo Error(string errorDescription = "Bir Hata Oluştu Lütfen Tekrar Deneyiniz Sorun Devam Ederse Yönetici İle İlsetişim Kurun", object errors = null)
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };

        }
        public static ErrorInfo AuthenticationError(string errorDescription = "Kullanıcı Bulunamadı", object errors = null)
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };
        }

        public static ErrorInfo FieldValidationError(object errors = null, string errorDescription = "Zorunlu Alanar Boş Bırakılamaz")
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };
        }

        public static ErrorInfo TokenError(object errors = null, string errorDescription = "Token Hatası")
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };
        }
        public static ErrorInfo TokenNotFoundError(object errors = null, string errorDescription = "Token Bilgisi Gelmedi")
        {
            return new ErrorInfo { Errors = errors, ErrorDescription = errorDescription };
        }
    }
}
