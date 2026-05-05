FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 5250

ENV ASPNETCORE_URLS=http://+:5250

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["chinookmssqlmvc.csproj", "src/"]
RUN dotnet restore "src/chinookmssqlmvc.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "chinookmssqlmvc.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "chinookmssqlmvc.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "chinookmssqlmvc.dll"]
