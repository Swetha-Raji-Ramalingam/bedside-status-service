# Bedside Status Service -- container build
#build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/BedsideStatus/BedsideStatus.csproj src/BedsideStatus/
RUN dotnet restore src/BedsideStatus/BedsideStatus.csproj
COPY . .

RUN dotnet publish src/BedsideStatus/BedsideStatus.csproj \
    -c Debug \
    -o /app/publish \
    --no-restore

#runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
#Removed root user and added app user for security
User app
ENTRYPOINT ["dotnet", "BedsideStatus.dll"]
