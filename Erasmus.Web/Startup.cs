using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Erasmus.Domain.Domain;
using Erasmus.Repository.Implementation;
using Erasmus.Repository.Interface;
using Erasmus.Service.Implementation;
using Erasmus.Service.Interface;
using Erasmus.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Erasmus.Domain;

namespace Erasmus.Web
{
    public class Startup
    {
        private EmailSettings emailService;

        public Startup(IConfiguration configuration)
        {
            emailService = new EmailSettings();
            Configuration = configuration;
            Configuration.GetSection("EmailSettings").Bind(emailService);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

            // repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IOrganizerRepository), typeof(OrganizerRepository));
            services.AddScoped(typeof(IParticipantRepository), typeof(ParticipantRepository));
            services.AddScoped(typeof(IUploadedFileRepository), typeof(UploadedFileRepository));
            services.AddScoped(typeof(INonGovProjectRepository), typeof(NonGovProjectRepository));
            services.AddScoped(typeof(INonGovProjectOrganizerRepository), typeof(NonGovProjectOrganizerRepository));
            services.AddScoped(typeof(IParticipantApplicationRepository), typeof(ParticipantApplicationRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped<EmailSettings>(email => emailService);
            services.AddScoped<IEmailService, EmailService>();

            // services
            services.AddTransient(typeof(ICityService), typeof(CityService));
            services.AddTransient(typeof(INonGovProjectService), typeof(NonGovProjectService));
            services.AddTransient(typeof(IOrganizerService), typeof(OrganizerService));
            services.AddTransient(typeof(IParticipantService), typeof(ParticipantService));
            services.AddTransient(typeof(IParticipantApplicationService), typeof(ParticipantApplicationService));

            services.AddIdentity<ErasmusUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<PasswordHasherOptions>(options =>
                 options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseNotyf();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
