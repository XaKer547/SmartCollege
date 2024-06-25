using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands.College;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Commands.College
{
    public class CreateCollegeAccountHandler : IRequestHandler<CreateCollegeAccountCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly ILogger<CreateRepresentativeOfCompanyCommandHandler> _logger;

        private readonly IMediator _mediator;

        public CreateCollegeAccountHandler(UserManager<AccountIdentity> userManager, ILogger<CreateRepresentativeOfCompanyCommandHandler> logger, IMediator mediator)
        {
            _userManager = userManager;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<HandleResult> Handle(CreateCollegeAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is not null)
                return HandleResult.Failure(StatusCodes.Status409Conflict, "Email уже занят!");

            try
            {
                var result = await _mediator.Send(new CreateCollegeAccountCommand(
                    request.UserId, 
                    request.Email, 
                    request.Password, 
                    request.Roles));

                var roles = request.Roles.Select(x=> x.ToString())
                    .ToArray();

                //await _mediator.Publish(new CreateCollegeAccountEvent(
                //    Guid.Parse(request.UserId),
                //    roles));

                return HandleResult.Success(StatusCodes.Status201Created, "Пользователь успешно создан!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "При создании аккаунта {@request} произошла ошибка", request);

                return HandleResult.Failure(StatusCodes.Status500InternalServerError, "Неизвестная ошибка!");
            }
        }
    }
}
