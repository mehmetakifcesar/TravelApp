using FluentValidation;
using TravelApp.Entity.DTO.ReservationDetail;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class ReservationDetailValidator:AbstractValidator<ReservationDetailDTORequest>
    {
        public ReservationDetailValidator()
        {
            RuleFor(q => q.DateTime).NotEmpty().WithMessage("Rezervasyon Tarihi Ve Saaati Boş Olamaz");
            RuleFor(q => q.DateTime).Must(DateTimeControl).WithMessage("Rezervasyon Tarihi Bugünden Önce Olamaz");
           
        }
        private bool DateTimeControl(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
