FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["log_elastic.csproj", "./"]
RUN dotnet restore "./log_elastic.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "log_elastic.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "log_elastic.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "log_elastic.dll"]
