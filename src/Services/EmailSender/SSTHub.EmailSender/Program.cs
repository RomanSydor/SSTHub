using SSTHub.EmailSender.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(builder.Configuration);

var app = builder.Build();
app.Run();