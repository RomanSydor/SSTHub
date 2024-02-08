namespace SSTHub.Identity.ServiceConfiguration
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
    }
}
