using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Commands;

namespace SmartCollege.SSO.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, HandleResult>
    {
        private readonly UserManager<AccountIdentity> _userManager;

        public UpdateAccountCommandHandler(UserManager<AccountIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandleResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return HandleResult.Failure(StatusCodes.Status404NotFound, "Пользователь не найден!");

            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, resetPasswordToken, request.Password);
            
            await _userManager.UpdateAsync(user);

            return HandleResult.Success(StatusCodes.Status204NoContent, "Пользователь обновлен!");
        }
    }
}
