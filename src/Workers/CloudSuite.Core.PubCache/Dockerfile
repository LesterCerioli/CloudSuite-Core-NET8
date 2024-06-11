#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Workers/CloudSuite.Core.PubCache/CloudSuite.Core.PubCache.csproj", "src/Workers/CloudSuite.Core.PubCache/"]
RUN dotnet restore "./src/Workers/CloudSuite.Core.PubCache/CloudSuite.Core.PubCache.csproj"
COPY . .
WORKDIR "/src/src/Workers/CloudSuite.Core.PubCache"
RUN dotnet build "./CloudSuite.Core.PubCache.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CloudSuite.Core.PubCache.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudSuite.Core.PubCache.dll"]