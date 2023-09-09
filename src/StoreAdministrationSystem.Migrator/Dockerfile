#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/StoreAdministrationSystem.Migrator/StoreAdministrationSystem.Migrator.csproj", "src/StoreAdministrationSystem.Migrator/"]
COPY ["src/StoreAdministrationSystem.DataAccess.PostgresSql/StoreAdministrationSystem.DataAccess.PostgresSql.csproj", "src/StoreAdministrationSystem.DataAccess.PostgresSql/"]
COPY ["src/StoreAdministrationSystem.DataAccess/StoreAdministrationSystem.DataAccess.csproj", "src/StoreAdministrationSystem.DataAccess/"]
COPY ["src/StoreAdministrationSystem.Domain/StoreAdministrationSystem.Domain.csproj", "src/StoreAdministrationSystem.Domain/"]
RUN dotnet restore "src/StoreAdministrationSystem.Migrator/StoreAdministrationSystem.Migrator.csproj"
COPY . .
WORKDIR "/src/src/StoreAdministrationSystem.Migrator"
RUN dotnet build "StoreAdministrationSystem.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreAdministrationSystem.Migrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAdministrationSystem.Migrator.dll"]