using System.Diagnostics;

namespace ObsWebUI.MyMiddlewares
{
	public class Mid1
	{
		public static void MyMiddleware1(HttpContext context)
		{
			Debug.WriteLine(context.Request.HttpContext.User.Identity.IsAuthenticated);
			Debug.WriteLine(context.Request.Host.Value);
			Debug.WriteLine(context.Request.Path);

			//return Task.CompletedTask;
		}
	}
}
