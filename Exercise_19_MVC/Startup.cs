using Exercise_21.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exercise_21
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("PhoneBookContext")));

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddMvc();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PhoneBookContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6; // минимальное количество знаков в пароле
                options.Lockout.MaxFailedAccessAttempts = 10; // количество попыток о блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // конфигурация Cookie с целью использования их для хранения авторизации
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Note}/{action=Index}/{id?}");
            });
        }
    }
}
