using MiniStock.WebApi.ExceptionHandlers;
using MiniStock.Application;
using MiniStock.Infrastructure;
//Herkes kendi paketini kursun, bana haber versin
var builder = WebApplication.CreateBuilder(args);

//görev dağılımı mantıgıdır
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Swagger ve Controller ayarları eskisi gibi kalsın
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//hata yünetimi
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();