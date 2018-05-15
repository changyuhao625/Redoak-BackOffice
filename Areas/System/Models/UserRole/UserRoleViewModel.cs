using System.Collections.Generic;
using Redoak.Domain.Model.Models;

namespace Redoak.Backoffice.Areas.System.Models.UserRole
{
    public class UserRoleModel
    {
        public IList<AspNetUsers> Users { get; set; }
    }
}