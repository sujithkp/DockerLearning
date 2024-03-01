FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Product.WebServer/*", "Product.WebServer/"]

RUN dotnet restore "./Product.WebServer/./Product.WebServer.csproj"

WORKDIR "/src/Product.WebServer"
RUN dotnet build "./Product.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Product.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 9080
EXPOSE 9081
ENV DOTNET_URLS=http://+:9080
ENV ASPNETCORE_ENVIRONMENT Development

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY --from=publish /app/Views .
ENTRYPOINT ["dotnet", "Product.WebServer.dll"]