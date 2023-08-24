using FluentValidation;
using TravelApp.Entity.DTO.Reservation;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class ReservationValidator:AbstractValidator<ReservationDTORequest>
    {
        public ReservationValidator()
        {
            RuleFor(q => q.ReservationDate).NotEmpty().WithMessage("Reservasyon Tarihini Giriniz");
            RuleFor(q => q.ReservationDate).Must(DateTimeControl).WithMessage("Reservasyon Tarihi Bugünden Önce Olamaz");
            RuleFor(q => q.NumberOfTravelers).NotEmpty().WithMessage("Yolcu Sayısını Giriniz");
            RuleFor(q=>q.Price).GreaterThan(1).WithMessage("Fiyat Sıfır(0) Olamaz");
            RuleFor(q => q.Price).NotEmpty().WithMessage("Fiyatı  Giriniz");
        }
        private bool DateTimeControl(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
