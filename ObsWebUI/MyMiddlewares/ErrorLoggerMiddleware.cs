namespace ObsWebUI.MyMiddlewares
{
	public class ErrorLoggerMiddleware(RequestDelegate next)
	{
		private readonly RequestDelegate _next = next;

		public async Task InvokeAsync(HttpContext context)
		{

			try
			{
				await next(context);
			}
			catch (Exception exception)
			{

				var logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
				var logFilePath = Path.Combine(logDirectoryPath, "ErrorLogs.txt");

				if (!Directory.Exists(logDirectoryPath))
				{
					Directory.CreateDirectory(logDirectoryPath);
				}

				var log = $"[{DateTime.Now}] Error: {exception.Message} \nStackTrace: {exception.StackTrace}\n";
				await File.AppendAllTextAsync(logFilePath, log);

				await _next(context);
			}

			
		}
	}
}
