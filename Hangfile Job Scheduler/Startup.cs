using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Hangfile_Job_Scheduler.Startup))]

namespace Hangfile_Job_Scheduler
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //https://docs.hangfire.io/en/latest/getting-started/index.html

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard("/hangfire",new DashboardOptions() { 
                //Authorization = new [] {new Models.MyAuthorizationFilter()},
                IsReadOnlyFunc = (DashboardContext context) => true
            });
           
            //BackgroundJob.Enqueue(() => Console.WriteLine("Fire and Forget!"));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring!"), Cron.Minutely());
            app.UseHangfireServer();
        }
    }
}
