#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 5296

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["productMicroService.csproj", "."]
RUN dotnet restore "./productMicroService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "productMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "productMicroService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "productMicroService.dll"]
