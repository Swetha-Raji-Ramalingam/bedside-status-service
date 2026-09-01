# Bedside Status Service -- container build
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
ENV ASPNETCORE_ENVIRONMENT=Development
RUN dotnet publish src/BedsideStatus/BedsideStatus.csproj -c Debug -o /app/out
EXPOSE 5000
#Removed root user and added app user for security
User app
CMD dotnet /app/out/BedsideStatus.dll
