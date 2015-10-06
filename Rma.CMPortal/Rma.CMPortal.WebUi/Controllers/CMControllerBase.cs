using System.Web.Mvc;
using Rma.CMPortal.WebUi.ActionResults;

namespace Rma.CMPortal.WebUi.Controllers
{
    public abstract class CMControllerBase : Controller
	{
		public BetterJsonResult<T> BetterJson<T>(T model)
		{
			return new BetterJsonResult<T>() {Data = model};
		}
	}
}