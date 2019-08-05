using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public class User:Microsoft.AspNetCore.Identity.IdentityUser
    {
        public ICollection<News> News { get; set; }
    }
}
