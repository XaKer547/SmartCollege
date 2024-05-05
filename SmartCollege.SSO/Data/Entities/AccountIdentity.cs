using Microsoft.AspNetCore.Identity;

namespace SmartCollege.SSO.Data.Entities
{
    public class AccountIdentity : IdentityUser
    {
        public bool Verified { get; set; }

        /// <summary>
        /// Тип пользователей которые можно создать
        /// </summary>
        public IdentityRole? AllowedUserRoleToCreate { get; set; }
    }
}
