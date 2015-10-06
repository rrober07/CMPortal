using System.Web.Mvc;

namespace Rma.CMPortal.WebUi.Controllers
{
	public class TemplateController : CMControllerBase
	{
		public PartialViewResult Render(string feature, string name)
		{
			return PartialView(string.Format("~/Scripts/app/{0}/templates/{1}", feature, name));
		}
	}
}