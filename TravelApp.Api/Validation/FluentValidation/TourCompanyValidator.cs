using FluentValidation;
using TravelApp.Entity.DTO.TourCompany;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class TourCompanyValidator:AbstractValidator<TourCompanyDTORequest>
    {
        public TourCompanyValidator()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Şirket İsmi Boş Bırakılamaz");
            RuleFor(q => q.Name).Length(2, 50).WithMessage("Şirket İsmi 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.Adress).NotEmpty().WithMessage("Şirket Adresi Boş Bırakılamaz");
            RuleFor(q => q.Adress).Length(5, 500).WithMessage("Şirket Adresi 5-500 Karakter Arasında Olmalıdır.");
            RuleFor(q => q.Email).NotEmpty().WithMessage("Şirket Email'i Boş Bırakılamaz");
            RuleFor(q => q.Email).EmailAddress().WithMessage("Şirket Email'i Formatı Yanlış");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage("Lütfen Şirketin Telefon Numarasını Girin");
            
        }
    }
}
