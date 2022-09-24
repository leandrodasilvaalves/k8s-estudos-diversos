FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ApiOptions__ForeCastApiUrl=''

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./OpenWeather.csproj", "OpenWeather.csproj"]
RUN dotnet restore "OpenWeather.csproj"
COPY . .
RUN dotnet build "OpenWeather.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenWeather.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenWeather.dll"]