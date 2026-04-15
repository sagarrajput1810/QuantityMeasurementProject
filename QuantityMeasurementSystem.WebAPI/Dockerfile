# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1. Project files copy karein (Caching improve karne ke liye)
COPY ["QuantityMeasurementSystem.WebAPI/QuantityMeasurementSystem.WebAPI.csproj", "QuantityMeasurementSystem.WebAPI/"]
COPY ["QuantityMeasurement.Models/QuantityMeasurement.Models.csproj", "QuantityMeasurement.Models/"]
COPY ["QuantityMeasurement.Business/QuantityMeasurement.Business.csproj", "QuantityMeasurement.Business/"]
COPY ["QuantityMeasurement.Repository/QuantityMeasurement.Repository.csproj", "QuantityMeasurement.Repository/"]

# 2. Dependencies restore karein
RUN dotnet restore "QuantityMeasurementSystem.WebAPI/QuantityMeasurementSystem.WebAPI.csproj"

# 3. Sara source code copy karein
COPY . .

# 4. App ko publish karein
WORKDIR "/src/QuantityMeasurementSystem.WebAPI"
RUN dotnet publish "QuantityMeasurementSystem.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Build stage se files copy karein
COPY --from=build /app/publish .

# Azure ke liye environment variables set karein
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

# Entrypoint mein manually port bind karein taaki Azure confuse na ho
ENTRYPOINT ["dotnet", "QuantityMeasurementSystem.WebAPI.dll", "--urls", "http://0.0.0.0:8080"]