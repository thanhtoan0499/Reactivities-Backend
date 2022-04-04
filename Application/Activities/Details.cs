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
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly ReactContext reactContext;

            public Handler(ReactContext reactContext)
            {
                this.reactContext = reactContext;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await reactContext.Activities.FindAsync(request.Id);
            }
        }
    }
}
