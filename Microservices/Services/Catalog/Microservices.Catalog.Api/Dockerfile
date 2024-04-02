FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src
COPY ["Services/Catalog/Microservices.Catalog.API/Microservices.Catalog.API.csproj", "Services/Catalog/Microservices.Catalog.API/"]
COPY ["Services/Catalog/Microservices.Catalog.Application/Microservices.Catalog.Application.csproj", "Services/Catalog/Microservices.Catalog.Application/"]
COPY ["Services/Catalog/Microservices.Catalog.Core/Microservices.Catalog.Core.csproj", "Services/Catalog/Microservices.Catalog.Core/"]
COPY ["Services/Catalog/Microservices.Catalog.Infrastructure/Microservices.Catalog.Infrastructure.csproj", "Services/Catalog/Microservices.Catalog.Infrastructure/"]
RUN dotnet restore "Services/Catalog/Microservices.Catalog.API/Microservices.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Microservices.Catalog.API"
RUN dotnet build "Microservices.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Catalog.API.dll"]