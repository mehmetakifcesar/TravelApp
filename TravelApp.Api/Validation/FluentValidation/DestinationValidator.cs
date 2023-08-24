using FluentValidation;
using Microsoft.Identity.Client;
using TravelApp.Entity.DTO.Destination;

namespace TravelApp.Api.Validation.FluentValidation
{
    public class DestinationValidator:AbstractValidator<DestinationDTORequest>
    {
        public DestinationValidator()
        {
            RuleFor(q=>q.Name).NotEmpty().WithMessage("Lütfen Varış Noktasını Yazın");
            RuleFor(q=>q.Description).NotEmpty().WithMessage("Bir Açıklama Yazın");
            RuleFor(q=>q.Description).Length(20,500).WithMessage("Açıklama 20-500 Karakter Arasında Olmalıdır.");
            RuleFor(q=>q.City).NotEmpty().WithMessage("Turun Düzenleneceği Şehri Seçin");
            RuleFor(q=>q.Country).NotEmpty().WithMessage("Turun Düzenleneceği Ülkeyi Seçin");
        }
       
    }
}
