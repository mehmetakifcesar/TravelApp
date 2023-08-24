using FluentValidation;
using TravelApp.Entity.DTO.TourGuide;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class TourGuideValidator:AbstractValidator<TourGuideDTORequest>
    {
        public TourGuideValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Rehber'in Adı Boş Olamaz");
            RuleFor(q=>q.LastName).NotEmpty().WithMessage("Rehber'in Soyadı Boş Olamaz");
            RuleFor(q=>q.Email).NotEmpty().WithMessage("Rehber'in Email'i Boş Olamaz");
           // RuleFor(q=>q.Email).EmailAddress().WithMessage("Rehber'in Email'i Yanlış");
            //RuleFor(q=>q.PhoneNumber).NotEmpty().WithMessage("Rehber'in Telefon Numarası Boş Olamaz");

        }
    }
}
