# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Ensure CA certificates are installed
RUN apt-get update && apt-get install -y \
    libssl-dev \
    ca-certificates \
    && apt-get clean

# Copy project files
COPY ContactsApplication.Application/ContactsApplication.Application.csproj ContactsApplication.Application/
COPY ContactsApplication.Domain/ContactsApplication.Domain.csproj ContactsApplication.Domain/
COPY ContactsApplication.Infrastructure/ContactsApplication.Infrastructure.csproj ContactsApplication.Infrastructure/
COPY ContactsApplication.API/ContactsApplication.API.csproj ContactsApplication.API/

# Restore packages
RUN dotnet restore "ContactsApplication.API/ContactsApplication.API.csproj"

# Copy all source files
COPY . .

# Build the project
WORKDIR "/src/ContactsApplication.API"
RUN dotnet build "ContactsApplication.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ContactsApplication.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "ContactsApplication.API.dll"]