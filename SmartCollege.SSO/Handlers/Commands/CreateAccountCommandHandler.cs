using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly ILogger<CreateAccountCommandHandler> _logger;

        private readonly IMediator _mediator;

        public CreateAccountCommandHandler(UserManager<AccountIdentity> userManager, ILogger<CreateAccountCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<HandleResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is not null)
                return HandleResult.Failure(StatusCodes.Status409Conflict, "Email уже занят!");

            try
            {
                var result = await _userManager.CreateAsync(new AccountIdentity
                {
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = false,
                    ChangeTempPassword = true,
                    LockoutEnabled = true,
                }, request.Password);

                if (!result.Succeeded)
                    return HandleResult.Failure(StatusCodes.Status400BadRequest, string.Concat(',', result.Errors
                        .Select(x => x.Description)));

                _mediator.Publish(new CreateAccountEvent(request.Email, $"", request.Phone, request.))

                return HandleResult.Success(StatusCodes.Status201Created, "Пользователь успешно создан!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "При создании аккаунта с почтой {Email} произошла ошибка", request.Email);

                return HandleResult.Failure(StatusCodes.Status500InternalServerError, "Неизвестная ошибка!");
            }
        }
    }
}
