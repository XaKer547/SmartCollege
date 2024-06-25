using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands.Account;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class CreateAccountCommandHandler
        : IRequestHandler<CreateRepresentativeOfCompanyAccountCommand, HandleResult<CreateAccountResult>>,
         IRequestHandler<CreateAccountByAdminCommand, HandleResult<CreateAccountResult>>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public CreateAccountCommandHandler(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandleResult<CreateAccountResult>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new AccountIdentity
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = !request.NeedSetNewPassword,
                ChangeTempPassword = request.NeedSetNewPassword,
                LockoutEnabled = !request.NeedSetNewPassword,
            };

            var result = await _userManager.CreateAsync(account, request.Password);

            if (!result.Succeeded)
                return HandleResult<CreateAccountResult>.Failure(StatusCodes.Status400BadRequest, string.Concat(',', result.Errors
                    .Select(x => x.Description)));

            try
            {
                foreach (var role in request.Roles)
                    await _userManager.AddToRoleAsync(account, role.ToString());
            }
            catch
            {
                await _userManager.DeleteAsync(account);

                throw;
            }

            return HandleResult<CreateAccountResult>.Success(StatusCodes.Status201Created, "Account created!", new CreateAccountResult(account.Id));
        }

        public Task<HandleResult<CreateAccountResult>> Handle(CreateRepresentativeOfCompanyAccountCommand request, CancellationToken cancellationToken)
        {
            return Handle((CreateAccountCommand)request, cancellationToken);
        }

        public Task<HandleResult<CreateAccountResult>> Handle(CreateAccountByAdminCommand request, CancellationToken cancellationToken)
        {
            return Handle((CreateAccountCommand)request, cancellationToken);
        }
    }
}
