using comperhensive_todo_list_api.Middleware;
using comperhensive_todo_list_api.Repository;
using comperhensive_todo_list_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDatabaseContext();

builder.Services.RegisterMainServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors((policy) =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseJwtMiddleware();

app.MapControllers();

app.Run();
