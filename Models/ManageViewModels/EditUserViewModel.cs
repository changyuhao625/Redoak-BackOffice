using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Redoak.Domain.Model.Models;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Models.ManageViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            UserRoleValue = new List<string>();
        }

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