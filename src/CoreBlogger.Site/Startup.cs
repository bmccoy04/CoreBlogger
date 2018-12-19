using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using CoreBlogger.Core.Handlers;
using CoreBlogger.Core.Queries;
using CoreBlogger.Core.Interfaces;
using CoreBlogger.Core.Providers;
using CoreBlogger.Infrastructure.Clients;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Site
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
            services.AddMediatR();
            services.AddTransient<IRequestHandler<GetBlogEntriesQuery, IList<GitHubBlogEntry>>, GetBlogEntriesHandler>();
            services.AddTransient<IGitHubEntryProvider, GitHubEntryProvider>();
            services.AddTransient<IGitHubClient, GitHubClient>();
            services.AddTransient<ICachedGitHubEntryProvider, CachedGitHubEntryProvider>();
            services.AddTransient<IApplicationCacheProvider, ApplicationCacheProvider>();
            services.AddHttpClient();
            services.AddLogging();
            services.AddMemoryCache();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
