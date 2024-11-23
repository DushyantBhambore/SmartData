using App.Core;
using Infrastructure;
using SignalRImplementation.SignaleR;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastructure(configure);

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddCors(optios =>
{
    optios.AddPolicy("Test",
        policy => policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("http://localhost:4200")
        );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Test");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();
