#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/StoreAdministrationSystem.Admin.Api/StoreAdministrationSystem.Admin.Api.csproj", "src/StoreAdministrationSystem.Admin.Api/"]
COPY ["src/StoreAdministrationSystem.Integration.Client/StoreAdministrationSystem.Integration.Client.csproj", "src/StoreAdministrationSystem.Integration.Client/"]
RUN dotnet restore "src/StoreAdministrationSystem.Admin.Api/StoreAdministrationSystem.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/StoreAdministrationSystem.Admin.Api"
RUN dotnet build "StoreAdministrationSystem.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreAdministrationSystem.Admin.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAdministrationSystem.Admin.Api.dll"]