using FluentValidation;
using TravelApp.Entity.DTO.Login;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginDTORequest>
    {
        public LoginValidator()
        {
            RuleFor(q=>q.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.UserName).Length(2, 50).WithMessage("Kullanıcı Adı 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Password).Length(5, 50).WithMessage("Şifre 5-50 Karakter Arasında Olmalıdır.");
           


        }
    }
}
