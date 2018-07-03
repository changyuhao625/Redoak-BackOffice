using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Redoak.Domain.Cache;
using Redoak.Domain.Model.ViewModel;

namespace Redoak.Backoffice.Areas
{
    public abstract class BaseController : Controller
    {
        public string UserId => this.UserManager.GetUserId(User);

        public UserManager<ApplicationUser> UserManager { get; set; }

        protected BaseController(ICacheService cache, UserManager<ApplicationUser> userManager)
        {
            Cache = cache;
            UserManager = userManager;
        }

        public ICacheService Cache { get; set; }

        public string GetModelStateMsg()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ModelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    sb.AppendLine(err.ErrorMessage);
                }
            }

            return sb.ToString();
        }
    }
}