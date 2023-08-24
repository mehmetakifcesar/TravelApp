using FluentValidation;
using TravelApp.Entity.DTO.Hotel;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class HotelValidator:AbstractValidator<HotelDTORequest>
    {
        public HotelValidator() 
        {   
            RuleFor(q=>q.Name).NotEmpty().WithMessage("Lütfen Otel Adını Girin");
            RuleFor(q => q.Name).Length(2, 50).WithMessage("Otel Adı 2-50 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.Price).NotEmpty().WithMessage("Lütfen Otel Ücretini Girin");
            RuleFor(q => q.Price).GreaterThan(0).WithMessage("Fiyat Sıfır(0) Olamaz");
            RuleFor(q=>q.Adress).NotEmpty().WithMessage("Lütfen Otel Adresini Girin");
            RuleFor(q => q.Adress).Length(5, 500).WithMessage("Otel Adresi 5-500 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.ReservationDate).NotEmpty().WithMessage("Lütfen Rezervasyon Tarihini Girin");
            RuleFor(q => q.ReservationDate).Must(DateTimeControl).WithMessage("Rezervasyon Tarihi Bügünden Önce Olamaz");
            RuleFor(q => q.Country).NotEmpty().WithMessage("Lütfen Ülke Seçin");
            RuleFor(q => q.City).NotEmpty().WithMessage("Lütfen Şehir Seçin");
            RuleFor(q=>q.RoomNumber).NotEmpty().WithMessage("Lütfen Oda Numarasını Girin");
            RuleFor(q=>q.NumberOfTravelers).NotEmpty().WithMessage("Lütfen Kişi Sayısını Girin");
            RuleFor(q=>q.NumberOfTravelers).GreaterThan(0).WithMessage("Kişi Sayısı 0 Olamaz");
        }
        private bool DateTimeControl(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
