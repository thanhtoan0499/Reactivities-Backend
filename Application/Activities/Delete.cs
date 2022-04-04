using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ReactContext reactContext;

            public Handler(ReactContext reactContext)
            {
                this.reactContext = reactContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await reactContext.Activities.FindAsync(request.Id);
                reactContext.Activities.Remove(activity);
                await reactContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
