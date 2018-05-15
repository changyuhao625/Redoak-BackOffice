using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas.System.Models.UserRole
{
    public class EditUserRoleViewModel
    {
        public EditUserRoleViewModel()
        {
            UserRoleValue = new List<string>();
        }
        [DisplayName("使用者名稱")]
        public string UserName { get; set; }
        public string UserId { get; set; }

        /// <summary>
        ///     User Info
        /// </summary>
        public ApplicationUser UserInfo { get; set; }

        /// <summary>
        ///     Whole System Role List
        /// </summary>
        public IList<IdentityRole> RoleList { get; set; }

        /// <summary>
        ///     Get the role of select user
        /// </summary>
        public IList<string> UserRoles { get; set; }

        /// <summary>
        ///     For model binding
        /// </summary>
        public IList<string> UserRoleValue { get; set; }
    }
}