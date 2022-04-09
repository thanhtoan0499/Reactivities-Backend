﻿using Domain;
using FluentValidation;

namespace Application.Activities;

public class ActivityValidator: AbstractValidator<Activity>
{
    public ActivityValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Tieu de khong duoc de trong");
    }
}