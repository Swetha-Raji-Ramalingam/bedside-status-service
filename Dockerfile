# Bedside Status Service -- container build
FROM mcr.microsoft.com/dotnet/sdk:latest
WORKDIR /app
COPY . .
ENV API_KEY=sk-live-9f8e7d6c5b4a
ENV ASPNETCORE_ENVIRONMENT=Development
RUN dotnet publish src/BedsideStatus/BedsideStatus.csproj -c Debug -o /app/out
EXPOSE 5000
CMD dotnet /app/out/BedsideStatus.dll
