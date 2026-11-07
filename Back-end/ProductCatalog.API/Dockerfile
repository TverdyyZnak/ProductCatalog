# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY . .

# Восстанавливаем зависимости
RUN dotnet restore "ProductCatalog.API/ProductCatalog.API.csproj"

# Собираем приложение
RUN dotnet publish "ProductCatalog.API/ProductCatalog.API.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# Этап запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "ProductCatalog.API.dll"]