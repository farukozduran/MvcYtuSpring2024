using Microsoft.AspNetCore.Authentication.Cookies;
using ObsWebUI.MyMiddlewares;
using ObsWebUI.Utilities;

namespace ObsWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddMemoryCache();

            builder.Services.AddHttpClient();

            builder.Services.AddSession();

            


            // Dependency Injection
            //         builder.Services.AddSingleton<IFacultyDal, FacultyDal>();
            //         builder.Services.AddSingleton<IDepartmentDal, DepartmentDal>();
            //         builder.Services.AddSingleton<IFacultyService, FacultyService>();
            //         builder.Services.AddSingleton<IDepartmentService, DepartmentService>();

            //builder.Services.AddSingleton<IUserDal, UserDal>();
            //builder.Services.AddSingleton<IOperationClaimDal, OperationClaimDal>();
            //builder.Services.AddSingleton<IUserOperationClaimDal, UserOperationClaimDal>();
            //builder.Services.AddSingleton<IUserService, UserService>();
            //         builder.Services.AddSingleton<IOperationClaimService, OperationClaimService>();
            //         builder.Services.AddSingleton<IUserOperationClaimService, UserOperationClaimService>();
            //builder.Services.AddSingleton<IAuthService, AuthService>();			
            //         builder.Services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
            //         //builder.Services.AddSingleton<ICacheProvider, RedisCacheProvider>();

            var cookieOptions = builder.Configuration.GetSection("CookieOptions").Get<CookieAuthOptions>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = cookieOptions.Name;
				options.LoginPath = cookieOptions.LoginPath;
				options.LogoutPath = cookieOptions.LogoutPath;
				options.AccessDeniedPath = cookieOptions.AccessDeniedPath;
				options.SlidingExpiration = cookieOptions.SlidingExpiration;
				options.ExpireTimeSpan = TimeSpan.FromSeconds(cookieOptions.TimeOut);
			}
);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            

            //app.Run(async (context) => Mid1.MyMiddleware1(context));

            //         app.Use(async (context, next) =>
            //         {
            //             Debug.WriteLine("M1- Request:" + context.Request.Path);
            //             await next();
            //             Debug.WriteLine("M1- Response:" + context.Response.StatusCode);
            //         });
            //app.Use(async (context, next) =>
            //{
            //	Debug.WriteLine("M2- Request:" + context.Request.Path);
            //	await next();
            //	Debug.WriteLine("M2- Response:" + context.Response.StatusCode);
            //});
            //app.Use(async (context, next) =>
            //{
            //	Debug.WriteLine("M3- Request:" + context.Request.Path);
            //	await next();
            //	Debug.WriteLine("M3- Response:" + context.Response.StatusCode);
            //});
            //app.Use(async (context, next) =>
            //{
            //	Debug.WriteLine("M4- Request:" + context.Request.Path);
            //	await next();
            //	Debug.WriteLine("M4- Response:" + context.Response.StatusCode);


            app.UseMiddleware<IPLoggerMiddleware>();

            app.UseMiddleware<AccessLoggerMiddleware>();

			app.UseMiddleware<ErrorLoggerMiddleware>();


            app.UseSession();

			app.UseAuthentication();

			app.UseAuthorization();			

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
