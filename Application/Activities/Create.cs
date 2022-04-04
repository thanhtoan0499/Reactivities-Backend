using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
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
                reactContext.Activities.Add(request.Activity);
                await reactContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
