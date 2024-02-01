using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Net.Http.Headers;

namespace WebAdminSPA.ServiceConfiguration
{
    public static class SpaConfiguration
    {
        public static void AddSpa(this IServiceCollection services, IConfiguration configuration)
        {
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(conf =>
            {
                conf.RootPath = "ClientApp/sst-hub-admin/build";
            });
        }

        public static void UseSpa(this IApplicationBuilder app, IWebHostEnvironment hostingEnvironment)
        {
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp/sst-hub-admin";
                if (hostingEnvironment.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }

                spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        var headers = ctx.Context.Response.GetTypedHeaders();
                        headers.CacheControl = new CacheControlHeaderValue
                        {
                            NoCache = true,
                            NoStore = true
                        };
                    }
                };

            });
        }

        public static void RunSpa(this IApplicationBuilder app, IWebHostEnvironment hostingEnvironment)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";

                string indexFile = System.IO.Path.Combine(hostingEnvironment.ContentRootPath, "ClientApp", "sst-hub-admin", "build", "index.html");
                await context.Response.SendFileAsync(indexFile);
            });
        }
    }
}
