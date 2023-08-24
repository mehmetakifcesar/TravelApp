using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TravelApp.Entity.Result
{
    public class ErrorResult<T>
    {
        public ErrorResult(T _data, string _mesaj, int _statusCode, ErrorInfo _errorInfo)
        {
            this.Data = _data;
            this.Message = _mesaj;
            this.StatusCode = _statusCode;
            this.ErrorInfo = _errorInfo;
        }

        public ErrorResult(T _data, string _message, int _statusCode)
        {
            this.Data = _data;
            this.StatusCode = _statusCode;
            this.Message = _message;
        }

        public ErrorResult(string _message, int _statusCode)
        {
            this.StatusCode = _statusCode;
            this.Message = _message;
        }

        public ErrorResult(string _message, int _statusCode, ErrorInfo _ErrorInfo)
        {
            this.StatusCode = _statusCode;
            this.Message = _message;
            this.ErrorInfo = _ErrorInfo;
        }


        public T Data { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public ErrorInfo ErrorInfo { get; }
        

        public static ErrorResult<T> SuccessWithData(T data, string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ErrorResult<T>(data, message, statusCode);
        }

        public static ErrorResult<T> SuccessWithoutData(string message = "İşlem Başarılı", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ErrorResult<T>(message, statusCode);
        }

        public static ErrorResult<T> SuccessNoDataFound(string message = "Sonuç Bulunamadı", int _statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ErrorResult<T>(message, _statusCode, ErrorInfo.NotFound());
        }

        public static ErrorResult<T> FieldValidationError(List<string>? errorMessages = null, string message = "Validasyon Hatası Oluştu", int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ErrorResult<T>(message, statusCode, ErrorInfo.FieldValidationError(errorMessages));
        }

        public static ErrorResult<T> Error(ErrorInfo errorInfo, string message = "Hata Oluştu", int statusCode = (int)HttpStatusCode.InternalServerError)
        {
            return new ErrorResult<T>(message, statusCode, ErrorInfo.Error());
        }


        public static ErrorResult<T> AuthenticationError(string message = "Kullanıcı Bulunamadı", int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ErrorResult<T>(message, statusCode, ErrorInfo.AuthenticationError());
        }
        public static ErrorResult<T> TokenError(ErrorInfo errorInfo, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new ErrorResult<T>("Hata Oluştu", statusCode, ErrorInfo.TokenError());
        }
        public static ErrorResult<T> TokenNotFoundError(ErrorInfo errorInfo, int statusCode = (int)HttpStatusCode.Unauthorized)
        {
            return new ErrorResult<T>("Hata Oluştu", statusCode, ErrorInfo.TokenNotFoundError());
        }
    }
}

