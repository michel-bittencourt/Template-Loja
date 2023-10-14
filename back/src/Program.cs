using Loja.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:Default"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.WithOrigins("http://localhost:4200");
    c.AllowAnyHeader();
    c.AllowAnyMethod();

    //c.AllowAnyHeader();
    //c.AllowAnyMethod();
    //c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
