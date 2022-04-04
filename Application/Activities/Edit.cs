using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Hander : IRequestHandler<Command>
        {
            private readonly ReactContext reactContext;
            private readonly IMapper mapper;

            public Hander (ReactContext reactContext, IMapper mapper)
            {
                this.reactContext = reactContext;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await reactContext.Activities.FindAsync(request.Activity.Id);
                mapper.Map(request.Activity, activity);
                await reactContext.SaveChangesAsync();
                return Unit.Value;
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
