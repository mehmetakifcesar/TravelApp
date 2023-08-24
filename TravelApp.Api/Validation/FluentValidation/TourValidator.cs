using FluentValidation;
using TravelApp.Entity.DTO.Tour;
using TravelApp.Entity.DTO.TourCompany;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class TourValidator:AbstractValidator<TourDTORequest>
    {
        public TourValidator()
        {
            RuleFor(q=>q.Name).NotEmpty().WithMessage("Tur Adı Boş Olamaz");
            RuleFor(q=>q.Name).Length(2,50).WithMessage("Tur Adı 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.Description).NotEmpty().WithMessage("Lütfen Tur Hakkında Kısa Açıklama Yazın");
            RuleFor(q=>q.Description).Length(20,500).WithMessage("Tur Açıklaması 20-500 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.Price).NotEmpty().WithMessage("Fiyat Bilgisi Boş Olamaz");
            RuleFor(q=>q.Price).GreaterThan(1).WithMessage("Fiyat Sıfır(0) Olamaz");
            RuleFor(q=>q.StartingDate).NotEmpty().WithMessage("Başlangıç Tarihini Seçin");
            RuleFor(q=>q.EndingDate).NotEmpty().WithMessage("Bitiş Tarihini Seçin");
            RuleFor(q => q.StartingDate).Must(DateTimeControl).WithMessage("Başlangıç Tarihi Bugünden Önce Olamaz");
            RuleFor(q => q.EndingDate).Must(DateTimeControl).WithMessage("Bitiş Tarihi Bugünden Önce Olamaz");
        }
        private bool DateTimeControl(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
