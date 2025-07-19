FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 7000

ENV ASPNETCORE_URLS=http://+:5000

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ProperTea.Company.Api/ProperTea.Company.Api.csproj", "ProperTea.Company.Api/"]
RUN dotnet restore "ProperTea.Company.Api/ProperTea.Company.Api.csproj"
COPY . .
WORKDIR "/src/ProperTea.Company.Api"
RUN dotnet build "ProperTea.Company.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ProperTea.Company.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProperTea.Company.Api.dll"]
