using Ejercicio.Hubs;

//Lado del servidor
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


/*
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500/index.html").AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();   
    });
});
*/




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x

.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()); 









app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");



app.Run();
