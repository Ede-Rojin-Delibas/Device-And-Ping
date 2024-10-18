using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();  // container a ekleme

// Add services to the container.

//Add caching 
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddAuthentication();//görevi??
builder.Services.AddPersistenceServices();
builder.Services.AddExternalServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();   //swagger eklendi.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin=>true).AllowCredentials()); //tamamýna izin verildi.

app.Run();
