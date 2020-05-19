using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ITP_App.DataAccess;
using ITP_App.ApplicationLogic.Abstractions;
using ITP_App.ApplicationLogic.Services;
using ITP_App.Data;

namespace ITP_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = @"Server=(localdb)\mssqllocaldb;Database=ITP_App;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ITP_AppContext>
                (options => options.UseSqlServer(connection));

            services.AddDbContext<ITP_AppDbContext>
                (options => options.UseSqlServer(connection));

            /*services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ITP_AppDbContext>();*/

            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IRuleRepository, RuleRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            

            services.AddScoped<AdminsService>();
            services.AddScoped<ClientsService>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 30;
                options.Lockout.AllowedForNewUsers = false;

                //User settings
                options.User.RequireUniqueEmail = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Client");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Client"));
            }

            var roleCheck1 = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck1)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //IdentityUser user1 = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
            //var User = new IdentityUser();
            //await UserManager.AddToRoleAsync(user1, "Admin");
        }
    }
}
