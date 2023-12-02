FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["square-service/square-service.csproj", "square-service/"]
RUN dotnet restore "square-service/square-service.csproj"
COPY . .
WORKDIR "/src/square-service"
RUN dotnet build "square-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "square-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "square-service.dll"]
