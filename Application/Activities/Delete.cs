using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
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
                var activity = await reactContext.Activities.FindAsync(request.Id);
                if (activity == null)
                {
                    return null;
                }
                reactContext.Activities.Remove(activity);
                var success = await reactContext.SaveChangesAsync() > 0;
                if (!success)
                {
                    return Result<Unit>.Failure("Xoa activity khong thanh cong");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
