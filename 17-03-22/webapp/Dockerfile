FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ApiOptions__ForeCastApiUrl=''

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./WebAppK8s.csproj", "WebAppK8s.csproj"]
RUN dotnet restore "WebAppK8s.csproj"
COPY . .
RUN dotnet build "WebAppK8s.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppK8s.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppK8s.dll"]