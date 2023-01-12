using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }
        public class CommandValidator : AbstractValidator<Create.Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }
        public class Hander : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ReactContext reactContext;
            private readonly IMapper mapper;

            public Hander (ReactContext reactContext, IMapper mapper)
            {
                this.reactContext = reactContext;
                this.mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await reactContext.Activities.FindAsync(request.Activity.Id);
                mapper.Map(request.Activity, activity);
                var result = await reactContext.SaveChangesAsync() > 0;
                if (!result)
                {
                    return Result<Unit>.Failure("Cap nhat activity khong thanh cong");
                }
                return Result<Unit>.Success(Unit.Value);
            }
            //public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            //{
            //    var activity = await reactContext.Activities.FindAsync(request.Activity.Id);
            //    activity.Title = request.Activity.Title ?? activity.Title;
            //    await reactContext.SaveChangesAsync();
            //    return Unit.Value;
            //}
        }
    }
}
