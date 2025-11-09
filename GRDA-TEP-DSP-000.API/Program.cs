using GRDA_TEP_DSP_000.API;
using GRDA_TEP_DSP_000.Application;
using GRDA_TEP_DSP_000.Application.Interface;
using GRDA_TEP_DSP_000.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db;Cache=Shared"));

builder.Services.AddScoped<IPalestraRepository, PalestraRepository>();

builder.Services.AddApplication(builder.Configuration);


builder.Services.AddMemoryCache();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
