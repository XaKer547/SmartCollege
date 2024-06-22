using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Models.Commands.College;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Commands.College
{
    public class UpdateCollegeAccountHandler : IRequestHandler<UpdateCollegeAccountCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly ILogger<CreateRepresentativeOfCompanyCommandHandler> _logger;

        private readonly IMediator _mediator;

        public UpdateCollegeAccountHandler(
            UserManager<AccountIdentity> userManager,
            ILogger<CreateRepresentativeOfCompanyCommandHandler> logger,
            IMediator mediator)
        {
            _userManager = userManager;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<HandleResult> Handle(UpdateCollegeAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return HandleResult.Failure(StatusCodes.Status404NotFound, "User not found");


            var needUpdateEmail = !user.Email?.Equals(request.Email) == true;

            if (needUpdateEmail)
            {
                var userByEmail = await _userManager.FindByIdAsync(request.Email);

                if (userByEmail is not null)
                    return HandleResult.Failure(StatusCodes.Status409Conflict, "Email уже занят!");
            }

            await _mediator.Send(new UpdateAccountCommand(user.Email!, request.Password, request.Roles, true));

            var roles = request.Roles.Select(x => x.ToString())
                .ToArray();

            await _mediator.Publish(new UpdateCollegeAccountEvent(
                Guid.Parse(request.UserId),
                roles));


            if (needUpdateEmail)
            {
                user.Email = request.Email;

                await _userManager.UpdateAsync(user);
            }

            return HandleResult.Success(StatusCodes.Status204NoContent, "User updated");
        }
    }
}
