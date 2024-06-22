using MediatR;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Events
{
    public class CreateAccountEventHandler<TContact> : INotificationHandler<CreateAccountEvent<TContact>>
    {
        public Task Handle(CreateAccountEvent<TContact> notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
