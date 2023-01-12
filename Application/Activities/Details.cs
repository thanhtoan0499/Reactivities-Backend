using Domain;
using MediatR;
using Persistence;
using Application.Core;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly ReactContext reactContext;

            public Handler(ReactContext reactContext)
            {
                this.reactContext = reactContext;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await reactContext.Activities.FindAsync(request.Id);
                //if (activity is null) throw new Exception("Khong tim thay activity");
                return Result<Activity>.Success(activity);
            }
        }
    }
}
