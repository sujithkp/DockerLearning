#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Product.WebServer/*", "Product.WebServer/"]
RUN dotnet restore "./Product.WebServer/./Product.WebServer.csproj"
WORKDIR "/src/Product.WebServer"