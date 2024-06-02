#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Rest/CloudSuite.Services.Core.API/CloudSuite.Services.Core.API.csproj", "src/Rest/CloudSuite.Services.Core.API/"]
COPY ["src/CloudSuite.Infrastructure.CrossCutting/CloudSuite.Infrastructure.CrossCutting.csproj", "src/CloudSuite.Infrastructure.CrossCutting/"]
COPY ["src/CloudSuite.Infrastructure/CloudSuite.Infrastructure.csproj", "src/CloudSuite.Infrastructure/"]
COPY ["src/Modules/CloudSuite.Domain/CloudSuite.Domain.csproj", "src/Modules/CloudSuite.Domain/"]
COPY ["src/Modules/CloudSuite.Commons/CloudSuite.Commons.csproj", "src/Modules/CloudSuite.Commons/"]
COPY ["src/Modules/CloudSuite.Modules.Application/CloudSuite.Modules.Application.csproj", "src/Modules/CloudSuite.Modules.Application/"]
RUN dotnet restore "./src/Rest/CloudSuite.Services.Core.API/CloudSuite.Services.Core.API.csproj"
COPY . .
WORKDIR "/src/src/Rest/CloudSuite.Services.Core.API"
RUN dotnet build "./CloudSuite.Services.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CloudSuite.Services.Core.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudSuite.Services.Core.API.dll"]