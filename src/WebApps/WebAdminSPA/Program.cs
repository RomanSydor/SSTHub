using WebAdminSPA.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSpaStaticFiles(conf =>
{
    conf.RootPath = "ClientApp/sst-hub-admin/build";
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

app.UseAuthorization();

app.MapRazorPages();
app.UseSpa(app.Environment);

app.Run();
