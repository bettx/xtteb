FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
COPY / /src
RUN dotnet publish /src -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build /app .
STOPSIGNAL SIGTERM
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "xbetter.dll"]