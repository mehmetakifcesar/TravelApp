using FluentValidation;
using TravelApp.Entity.DTO.UserDTO;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class UserValidator:AbstractValidator<UserDTORequest>
    {
        public UserValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.FirstName).Length(2, 50).WithMessage("Ad 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.LastName).Length(2, 50).WithMessage("Soyad 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Username).Length(2, 50).WithMessage("Kullanıcı Adı 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Password).Length(5, 50).WithMessage("Şifre 5-50 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.Email).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.Email).EmailAddress().WithMessage("E-Posta Formatı Yanlış");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Olamaz");
            RuleFor(q => q.Adress).NotEmpty().WithMessage("Adres Boş Olamaz");
            RuleFor(q => q.Adress).Length(5, 500).WithMessage("Adres 5-500 Karakter Arasında Olmalıdır.");
        }
    }
}
