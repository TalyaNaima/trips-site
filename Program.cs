using BLL.Functions;
using BLL.Interfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TripContext>(options => options.UseSqlServer("Server=.;Database=Trip;TrustServerCertificate=True;Trusted_Connection=True;"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IInvitationDAL), typeof(InvitationFunc));
builder.Services.AddScoped(typeof(IInvitationBll), typeof(InvitationFuncBll));

builder.Services.AddScoped(typeof(ITripDAL), typeof(TripFunc));
builder.Services.AddScoped(typeof(ITripBll), typeof(TripFuncBll));

builder.Services.AddScoped(typeof(ITypeTripDAL), typeof(TypeTripFunc));
builder.Services.AddScoped(typeof(ITypeTripBll), typeof(TypeTripFuncBll));

builder.Services.AddScoped(typeof(IUserDAL), typeof(UserFunc));
builder.Services.AddScoped(typeof(IUserBll), typeof(UserFuncBll));


builder.Services.AddCors(opotion => opotion.AddPolicy("all",//נתינת שם להרשאה
                p => p.AllowAnyOrigin()//מאפשר כל מקור
                .AllowAnyMethod()//כל מתודה - פונקציה
                .AllowAnyHeader()));//וכל כותרת פונקציה
//השורה הבאה נותנת פקודה להחזיר את כל המשתנים כמו שהם
//בלי להפוך את האותיות הראשונות לקטנות
//builder.Services.AddControllers()
//           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();
app.UseCors("all");
//אפשרות להשתמש בקבצים הנמצאים בשרת
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
