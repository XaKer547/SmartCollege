using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands.Account;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public UpdateAccountHandler(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandleResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return HandleResult.Failure(StatusCodes.Status404NotFound, "User not found");

            if (request?.Password is not null)
            {
                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, resetPasswordToken, request.Password);

                await _userManager.UpdateAsync(user);

                if (request.NeedSetPasswordByUser)
                {
                    user.ChangeTempPassword = request.NeedSetPasswordByUser;

                    await _userManager.UpdateAsync(user);
                }
            }

            if (request?.Roles is not null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var rolesToAdd = request.Roles.Select(x => x.ToString());

                try
                {
                    await _userManager.RemoveFromRolesAsync(user, roles);

                    await _userManager.AddToRolesAsync(user, rolesToAdd);
                }
                catch
                {
                    await _userManager.RemoveFromRolesAsync(user, rolesToAdd);

                    await _userManager.AddToRolesAsync(user, roles);

                    throw;
                }
            }

            if (request!.IsBlocked != user.LockoutEnabled)
            {
                user.LockoutEnabled = request!.IsBlocked.GetValueOrDefault();
                
                await _userManager.UpdateAsync(user);
            }

            return HandleResult.Success(StatusCodes.Status204NoContent, "Account updated!");
        }
    }
}
