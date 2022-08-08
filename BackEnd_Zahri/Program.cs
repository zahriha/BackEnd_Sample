using BackEnd.Data;
using BackEnd.Data.DAL;
using BackEnd.Data.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//menambahkan konfigurasi EF
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DataConnection")).EnableSensitiveDataLogging());

//menambahkan configurasi auto mapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//inject DAL class
builder.Services.AddScoped<IStudent, StudentDAL>();
builder.Services.AddScoped<ICourse, CourseDAL>();
builder.Services.AddScoped<IStudent, StudentDAL>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
