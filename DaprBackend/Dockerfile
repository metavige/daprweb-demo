﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DaprBackend/DaprBackend.csproj", "DaprBackend/"]
RUN dotnet restore "DaprBackend/DaprBackend.csproj"
COPY . .
WORKDIR "/src/DaprBackend"
RUN dotnet build "DaprBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprBackend.dll"]
