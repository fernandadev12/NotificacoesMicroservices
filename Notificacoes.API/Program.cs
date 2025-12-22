// Notifications.API/Program.cs
using Microsoft.EntityFrameworkCore;
using Notifications.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NotificationsDbContext>(options =>
{
    options.UseMongoDB(
        connectionString: builder.Configuration.GetConnectionString("Mongo"),
        databaseName: builder.Configuration["MongoDatabase"]);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeta repositórios e serviços de aplicação
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Worker de entrega
builder.Services.AddHostedService<NotificationDispatcherWorker>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();