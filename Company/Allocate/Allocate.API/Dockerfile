#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Allocate/Allocate.API/Allocate.API.csproj", "Allocate/Allocate.API/"]
COPY ["Allocate/Allocate.Domain/Allocate.Domain.csproj", "Allocate/Allocate.Domain/"]
COPY ["Allocate/Allocate.Data/Allocate.Data.csproj", "Allocate/Allocate.Data/"]
COPY ["Common/Messaging.Service/Messaging.Service.csproj", "Common/Messaging.Service/"]
RUN dotnet restore "Allocate/Allocate.API/Allocate.API.csproj"
COPY . .
WORKDIR "/src/Allocate/Allocate.API"
RUN dotnet build "Allocate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Allocate.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Allocate.API.dll"]
