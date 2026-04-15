# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Saare projects copy karein taki dependencies mil jayein
COPY ["QuantityMeasurementSystem.WebAPI/QuantityMeasurementSystem.WebAPI.csproj", "QuantityMeasurementSystem.WebAPI/"]
COPY ["QuantityMeasurement.Models/QuantityMeasurement.Models.csproj", "QuantityMeasurement.Models/"]
COPY ["QuantityMeasurement.Business/QuantityMeasurement.Business.csproj", "QuantityMeasurement.Business/"]
COPY ["QuantityMeasurement.Repository/QuantityMeasurement.Repository.csproj", "QuantityMeasurement.Repository/"]

# Restore sirf WebAPI ko karein (Dependencies apne aap ho jayengi)
RUN dotnet restore "QuantityMeasurementSystem.WebAPI/QuantityMeasurementSystem.WebAPI.csproj"

# Baaki sara code copy karein
COPY . .
WORKDIR "/src/QuantityMeasurementSystem.WebAPI"
RUN dotnet publish "QuantityMeasurementSystem.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "QuantityMeasurementSystem.WebAPI.dll"]
