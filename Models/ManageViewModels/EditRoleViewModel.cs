using System.Collections.Generic;
using Redoak.Domain.Model.Models;

namespace Redoak.Backoffice.Models.ManageViewModels
{
    public class EditRoleViewModel
    {
        public IList<AspNetUsers> Users { get; set; }
    }
}