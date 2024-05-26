using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands.RepresentativeOfCompany;
using SmartCollege.SSO.Models.Events;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class CreateRepresentativeOfCompanyCommandHandler : IRequestHandler<CreateRepresentativeOfCompanyCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        private readonly AuthorizationDbContext _authorizationDbContext;

        private readonly ILogger<CreateRepresentativeOfCompanyCommandHandler> _logger;

        private readonly IMediator _mediator;

        public CreateRepresentativeOfCompanyCommandHandler(UserManager<AccountIdentity> userManager, ILogger<CreateRepresentativeOfCompanyCommandHandler> logger, IMediator mediator, AuthorizationDbContext authorizationDbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _mediator = mediator;
            _authorizationDbContext = authorizationDbContext;
        }

        public async Task<HandleResult> Handle(CreateRepresentativeOfCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Account.Email);
            if (user is not null)
                return HandleResult.Failure(StatusCodes.Status409Conflict, "Email уже занят!");

            try
            {
                var result = await _mediator.Send(request.Account);

                var account = await _userManager.FindByIdAsync(result.Result!.UserId) ?? throw new Exception();
                
                await _authorizationDbContext.RepresentationOfTheCompanies.AddAsync(new RepresentationOfTheCompany
                {
                    Company = request.Company,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Phone = request.Phone,
                    Account = account
                });

                await _authorizationDbContext.SaveChangesAsync();

                await _mediator.Publish(new CreateAccountEvent(
                    request.Account.Email,
                    $"{request.MiddleName} {request.FirstName} {request.LastName}",
                    request.Phone,
                    request.Company));

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
