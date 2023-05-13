using DAL;
using UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectFrontendServices();

builder.Services.AddSingleton<TestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseFrontendStaticFiles();
app.OpenBrowserWhenReady();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://*:2607");