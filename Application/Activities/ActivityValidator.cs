using Domain;
using FluentValidation;

namespace Application.Activities;

public class ActivityValidator: AbstractValidator<Activity>
{
    public ActivityValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Tieu de khong duoc de trong");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Khong duoc de trong");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Khong duoc de trong");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Khong duoc de trong");
        RuleFor(x => x.City).NotEmpty().WithMessage("Khong duoc de trong");
        RuleFor(x => x.Venue).NotEmpty().WithMessage("Khong duoc de trong");
    }
}