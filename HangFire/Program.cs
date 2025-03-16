using Hangfire;
using HangFire.Context;
using HangFire.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(cfr =>
{
    cfr.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate("test-job", () => BackgroundTestService.Test(), Cron.Minutely());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
