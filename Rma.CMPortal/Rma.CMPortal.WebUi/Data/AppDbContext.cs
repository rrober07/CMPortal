using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rma.CMPortal.WebUi.Core;

namespace Rma.CMPortal.WebUi.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public IDbSet<Core.Submitter> Submitters { get; set; }

    }

}