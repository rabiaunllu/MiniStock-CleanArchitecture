using MiniStock.Application;
using MiniStock.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// API ve Swagger ayarları
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Veritabanımızı (SQLite) sisteme tanıtıyoruz
builder.Services.AddDbContext<AppDbContext>();

// 2. İş İlanı (Interface) ile İşi Yapan Elemanı (Repository) eşleştiriyoruz
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// 3. MediatR'ı tanıtıyoruz ki Application katmanındaki Handler sınıflarımızı bulabilsin
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IProductRepository).Assembly));

var app = builder.Build();

// UFAK BİR HİLE: Uygulama her çalıştığında veritabanı dosyamızı (ministock.db) otomatik oluştursun
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); 
}

// Swagger arayüzünü aktif ediyoruz
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();