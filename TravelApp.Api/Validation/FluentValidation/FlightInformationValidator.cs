using FluentValidation;
using TravelApp.Entity.DTO.FlightInformation;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class FlightInformationValidator:AbstractValidator<FlightInformationDTORequest>
    {
        public FlightInformationValidator()
        {
            RuleFor(q => q.Airline).NotEmpty().WithMessage("Havayolu Şirketinin İsmini Giriniz");
            RuleFor(q => q.DepartureDate).NotEmpty().WithMessage("Uçağın Kalkış Saatini Giriniz");
            RuleFor(q => q.DepartureDate).Must(DateTimeControl).WithMessage("Uçağın Kalkış Saati Bugünden Önce Olamaz");
            RuleFor(q => q.ArrivalDate).NotEmpty().WithMessage("Uçağın Tahmini İniş Saatini Giriniz");
            //RuleFor(q => q.ArrivalDate).Must(DateTimeControl).WithMessage("Uçağın Tahmini İniş Saati Bugünden Önce Olamaz");
            RuleFor(q => q.Origin).NotEmpty().WithMessage("Uçağın Kalkış Yerini Giriniz");
            RuleFor(q => q.Destination).NotEmpty().WithMessage("Uçağın İniş Yerini Giriniz");
            RuleFor(q => q.Price).NotEmpty().WithMessage("Bilet Fiyatını Giriniz");
            RuleFor(q => q.Price).GreaterThan(1).WithMessage("Fiyat Sıfır(0) Olamaz");

        }
        private bool DateTimeControl(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
