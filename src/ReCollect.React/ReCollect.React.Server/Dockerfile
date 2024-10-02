#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ReCollect.React/recollect.react.client/nuget.config", "src/ReCollect.React/recollect.react.client/"]
COPY ["src/ReCollect.React/ReCollect.React.Server/ReCollect.Server.csproj", "src/ReCollect.React/ReCollect.React.Server/"]
COPY ["src/ReCollect.Infrastructure/ReCollect.Infrastructure.csproj", "src/ReCollect.Infrastructure/"]
COPY ["src/ReCollect.Application/ReCollect.Application.csproj", "src/ReCollect.Application/"]
COPY ["src/ReCollect.Domain/ReCollect.Domain.csproj", "src/ReCollect.Domain/"]
COPY ["src/ReCollect.React/recollect.react.client/recollect.react.client.esproj", "src/ReCollect.React/recollect.react.client/"]
RUN dotnet restore "./src/ReCollect.React/ReCollect.React.Server/ReCollect.Server.csproj"
COPY . .
WORKDIR "/src/src/ReCollect.React/ReCollect.React.Server"
RUN dotnet build "./ReCollect.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReCollect.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReCollect.Server.dll"]