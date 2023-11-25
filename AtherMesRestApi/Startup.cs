using AtherMesRestApi.MESModels;
using AtherMesRestApi.PushNotification;
using CorePush.Apple;
using CorePush.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz;

namespace AtherMesRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }    



        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            //DB connection string
            //var mes_connection = Configuration.GetConnectionString("mesdev");
            //var mes_connection = Configuration.GetConnectionString("mesprod_E");
            //var mes_connection = Configuration.GetConnectionString("mesprod_F");
            //var mes_connection = Configuration.GetConnectionString("mesprod_G");
            var mes_connection = Configuration.GetConnectionString("mesprod_Common");
            //var mes_connection = Configuration.GetConnectionString("mesprod_V1_Line");
            //var mes_connection = Configuration.GetConnectionString("mesprod_Vehicle_Common");

            //Add DB
            services.AddDbContextPool<MESDBContext>(options => options.UseSqlServer(mes_connection, options => options.EnableRetryOnFailure()).EnableSensitiveDataLogging());

            //Add Controllers
            services.AddControllers();

            //FCM
            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();

            // Configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            //Add MVCCore
            services.AddMvcCore()
            .AddApiExplorer()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.AllowTrailingCommas = true;

            });

            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AtherMesRestApi", Version = "v1" });
            });

            //Add Quarts scheduler
            services.AddQuartz(q =>
            {
                //q.UseMicrosoftDependencyInjectionScopedJobFactory();
                //var jobKey = new JobKey("DemoJob");
                //q.AddJob<DemoJob>(opts => opts.WithIdentity(jobKey));

                //q.AddTrigger(opts => opts
                //    .ForJob(jobKey)
                //    .WithIdentity("DemoJob-trigger")
                //    .WithCronSchedule("0 0/5 * * * ?"));

                //var jobKey2 = new JobKey("PBJob");
                //q.AddJob<PBJob>(opts => opts.WithIdentity(jobKey2));

                //q.AddTrigger(opts => opts
                //    .ForJob(jobKey2)
                //    .WithIdentity("PBJob-trigger")
                //    .WithCronSchedule("0 0/5 * * * ?"));

                //var jobKey3 = new JobKey("LogoutJob");
                //q.AddJob<LogoutJob>(opts => opts.WithIdentity(jobKey3));

                //q.AddTrigger(opts => opts
                //    .ForJob(jobKey3)
                //    .WithIdentity("LogoutJob-trigger")
                //    .WithCronSchedule("0 0/1 * * * ?"));

            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtherMesRestApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseStaticFiles();


            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtherMesRestApi v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
