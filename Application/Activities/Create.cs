using Domain;
using MediatR;
using Persistence;
using Application.Core;
using FluentValidation;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }
 
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ReactContext reactContext;

            public Handler(ReactContext reactContext)
            {
                this.reactContext = reactContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                reactContext.Activities.Add(request.Activity);
               var success = await reactContext.SaveChangesAsync() > 0 ;
               if (!success)
               {
                   return Result<Unit>.Failure("Khong the tao activity");
               }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
