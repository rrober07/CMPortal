using System.Web;
using System.Web.Mvc;
using Rma.CMPortal.WebUi.Utilities;

namespace Rma.CMPortal.WebUi.Helpers
{
	public static class JsonHtmlHelpers
	{
		public static IHtmlString JsonFor<T>(this HtmlHelper helper, T obj)
		{
			return helper.Raw(obj.ToJson());
		}
	}
}