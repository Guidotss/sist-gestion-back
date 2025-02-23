FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["sist-gestion-backend/sist-gestion-backend.csproj", "sist-gestion-backend/"]
RUN dotnet restore "sist-gestion-backend/sist-gestion-backend.csproj"
COPY . .
WORKDIR "/src/sist-gestion-backend"
RUN dotnet build "sist-gestion-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "sist-gestion-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sist-gestion-backend.dll"]
