using System;
using ChatBotNetCoreSample.Controllers;
using ChatBotNetCoreSample.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder.BotFramework;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatBotNetCoreSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            //services.AddDbContext<DatabaseContext>(options =>
            //     options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddBot<SimplePromptBot>(options =>
            //{
            //    options.CredentialProvider = new ConfigurationCredentialProvider(Configuration);

            //    options.Middleware.Add(new CatchExceptionMiddleware<Exception>(async (context, exception) =>
            //    {
            //        await context.TraceActivity("EchoBot Exception", exception);
            //        await context.SendActivity("Sorry, it looks like something went wrong!");
            //    }));

            //    // The Memory Storage used here is for local bot debugging only. When the bot
            //    // is restarted, anything stored in memory will be gone. 
            //    IStorage dataStore = new MemoryStorage();

            //    options.Middleware.Add(new ConversationState<HelloBot>(dataStore));
            //});

            //services.AddMvc();
            services.AddSingleton(_ => Configuration);
            services.AddBot<HelloBot>(options =>
            {
                options.CredentialProvider = new ConfigurationCredentialProvider(Configuration);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseBotFramework();
        }
    }
}
