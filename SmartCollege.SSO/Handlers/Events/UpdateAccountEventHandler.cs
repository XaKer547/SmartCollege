using MediatR;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Events
{
    public class UpdateAccountEventHandler<TContract> : INotificationHandler<UpdateAccountEvent<TContract>>
    {
        public Task Handle(UpdateAccountEvent<TContract> notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
