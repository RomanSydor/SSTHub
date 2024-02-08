using Microsoft.AspNetCore.Identity;
using SSTHub.Identity.Models;
using SSTHub.Identity.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddJwtToken(builder.Configuration);
builder.Services.AddSpaStaticFiles(conf =>
{
    conf.RootPath = "ClientApp/sst-hub-identity/build";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSpaStaticFiles();

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseSpa(app.Environment);

app.Run();
