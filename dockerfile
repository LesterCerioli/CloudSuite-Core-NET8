# Use .NET 8.0 ASP.NET Core runtime as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use .NET 8.0 SDK for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Rest/CloudSuite.Services.Core.API/CloudSuite.Services.Core.API.csproj", "src/Rest/CloudSuite.Services.Core.API/"]
RUN dotnet restore "src/Rest/CloudSuite.Services.Core.API/CloudSuite.Services.Core.API.csproj"
COPY . .
WORKDIR "/src/src/Rest/CloudSuite.Services.Core.API"
RUN dotnet build "CloudSuite.Services.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CloudSuite.Services.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: Use the base image and copy the published output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudSuite.Services.Core.API.dll"]
