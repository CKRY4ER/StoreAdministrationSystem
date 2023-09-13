#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/StoreAdministrationSystem.Api/StoreAdministrationSystem.Api.csproj", "src/StoreAdministrationSystem.Api/"]
COPY ["src/StoreAdministrationSystem.Application/StoreAdministrationSystem.Application.csproj", "src/StoreAdministrationSystem.Application/"]
COPY ["src/StoreAdministrationSystem.DataAccess.PostgresSql/StoreAdministrationSystem.DataAccess.PostgresSql.csproj", "src/StoreAdministrationSystem.DataAccess.PostgresSql/"]
COPY ["src/StoreAdministrationSystem.DataAccess/StoreAdministrationSystem.DataAccess.csproj", "src/StoreAdministrationSystem.DataAccess/"]
COPY ["src/StoreAdministrationSystem.Domain/StoreAdministrationSystem.Domain.csproj", "src/StoreAdministrationSystem.Domain/"]
COPY ["src/StoreAdministrationSystem.ReadModel.PostgresSql/StoreAdministrationSystem.ReadModel.PostgresSql.csproj", "src/StoreAdministrationSystem.ReadModel.PostgresSql/"]
COPY ["src/StoreAdministrationSystem.ReadModel/StoreAdministrationSystem.ReadModel.csproj", "src/StoreAdministrationSystem.ReadModel/"]
RUN dotnet restore "src/StoreAdministrationSystem.Api/StoreAdministrationSystem.Api.csproj"
COPY . .
WORKDIR "/src/src/StoreAdministrationSystem.Api"
RUN dotnet build "StoreAdministrationSystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreAdministrationSystem.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAdministrationSystem.Api.dll"]