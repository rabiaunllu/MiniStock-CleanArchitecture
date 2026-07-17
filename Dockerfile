# 1. AŞAMA: İnşa Etme (Build) - .NET SDK kullanarak kodları derliyoruz
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Sadece proje (.csproj) dosyalarını COPY ile kopyalayıp bağımlılıkları yüklüyoruz (Böylece sistem daha hızlı çalışır)
COPY ["MiniStock.WebApi/MiniStock.WebApi.csproj", "MiniStock.WebApi/"]
COPY ["MiniStock.Application/MiniStock.Application.csproj", "MiniStock.Application/"]
COPY ["MiniStock.Domain/MiniStock.Domain.csproj", "MiniStock.Domain/"]
COPY ["MiniStock.Infrastructure/MiniStock.Infrastructure.csproj", "MiniStock.Infrastructure/"]
RUN dotnet restore "MiniStock.WebApi/MiniStock.WebApi.csproj"

# Kalan tüm C# kodlarını COPY ile içeri alıyoruz ve projeyi yayınlanmaya hazır hale getiriyoruz (Publish)
COPY . .
WORKDIR "/src/MiniStock.WebApi"
RUN dotnet publish "MiniStock.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 2. AŞAMA: Çalıştırma (Runtime) - Sadece çalışması için gereken hafif sürümü alıyoruz
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# Build aşamasında derlenen dosyaları COPY ile bu hafif imajın içine aktarıyoruz
COPY --from=build /app/publish .

# Konteyner ayağa kalktığında çalışacak olan ana komutumuz
ENTRYPOINT ["dotnet", "MiniStock.WebApi.dll"]