FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["CloudNativveApp.Api.csproj", "./"]
RUN dotnet restore "./CloudNativveApp.Api.csproj"

COPY . .
RUN dotnet publish "CloudNativveApp.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

WORKDIR /app

USER app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CloudNativveApp.Api.dll"]