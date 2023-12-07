#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["userMicroServices.Unit/userMicroServices.Unit.csproj", "userMicroServices.Unit/"]
COPY ["userMicroService/userMicroService.csproj", "userMicroService/"]
RUN dotnet restore "userMicroServices.Unit/userMicroServices.Unit.csproj"
COPY . .
WORKDIR "/src/userMicroServices.Unit"
RUN dotnet build "userMicroServices.Unit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "userMicroServices.Unit.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet test "userMicroServices.Unit.csproj" -c Release --no-restore
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "userMicroServices.Unit.dll"]
