FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SquareService.Application/SquareService.Application.csproj", "SquareService.Application/"]
RUN dotnet restore "SquareService.Application/SquareService.Application.csproj"
COPY . .
WORKDIR "/src/SquareService.Application"
RUN dotnet build "SquareService.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SquareService.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SquareService.Application.dll"]
