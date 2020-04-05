
namespace RPGCalendar
{
    using System;
    using System.IO;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Core;
    using Core.Models;
    using Core.Services;
    using Data;
    using Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Authorization;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get;}
        public RpgCalendarSettings AppSettings { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Env = env;
            Configuration = configuration;
            AppSettings = GetRpgCalendarSettings();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            //TODO: Add authentication filter for pages other than login and new user
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AuthorizeFilter(
                    new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build()));
            });
            services.AddSwaggerDocument();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            if (Env.IsProduction())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.EnableSensitiveDataLogging()
                        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                services.AddDbContext<AuthenticationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AuthConnection")));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.EnableSensitiveDataLogging()
                        .UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
                services.AddDbContext<AuthenticationDbContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("AuthConnection")));

            }

            services
                .AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AuthenticationDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.Configure<RpgCalendarSettings>(Configuration.GetSection(nameof(RpgCalendarSettings)));
            services.AddTransient<IGameNoteService, GameNoteService>()
                    .AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAutoMapper(new[] { typeof(AutomapperConfigurationProfile).Assembly });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                options.LoginPath = "/";
                options.SlidingExpiration = true;
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddSession(options =>
                {
                    options.Cookie.Name = $".{AppSettings.ApplicationName!}.Session";
                    options.IdleTimeout = TimeSpan.FromHours(1);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                }

            );
            services.AddHttpContextAccessor();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi(x => x.PostProcess = (doc, _) =>
            {
                doc.Info.Title = $"{AppSettings.ApplicationName} API ({env.EnvironmentName})";
            });

            app.UseSwaggerUi3();

            app.UseCors();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }

        private RpgCalendarSettings GetRpgCalendarSettings()
        {
            var appSettings = new RpgCalendarSettings();
            Configuration.GetSection(nameof(RpgCalendarSettings)).Bind(appSettings);
            return appSettings;
        }
    }
}
