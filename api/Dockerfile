# =========================
# 1️⃣ Build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY api.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./

# Build & publish
RUN dotnet publish -c Release -o out

# =========================
# 2️⃣ Runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

# ASP.NET Core default port inside container
EXPOSE 8080

ENTRYPOINT ["dotnet", "api.dll"]
