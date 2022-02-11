#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Onboard/Onboard.API/Onboard.API.csproj", "Onboard/Onboard.API/"]
COPY ["Onboard/Onboard.Domain/Onboard.Domain.csproj", "Onboard/Onboard.Domain/"]
COPY ["Onboard/Onboard.Data/Onboard.Data.csproj", "Onboard/Onboard.Data/"]
COPY ["Common/Messaging.Service/Messaging.Service.csproj", "Common/Messaging.Service/"]
RUN dotnet restore "Onboard/Onboard.API/Onboard.API.csproj"
COPY . .
WORKDIR "/src/Onboard/Onboard.API"
RUN dotnet build "Onboard.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboard.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboard.API.dll"]
