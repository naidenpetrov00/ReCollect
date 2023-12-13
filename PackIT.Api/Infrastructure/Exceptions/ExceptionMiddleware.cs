namespace PackIT.Api.Infrastructure.Exceptions
{
	internal sealed class ExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = 400;
				context.Response.Headers.Add("content-type", "application/json");

			}
		}
	}
}
