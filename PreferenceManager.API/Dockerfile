FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PreferenceManager.API/PreferenceManager.API.csproj", "PreferenceManager/"]
RUN dotnet restore "PreferenceManager.API/PreferenceManager.API.csproj"
COPY . .
WORKDIR "/src/PreferenceManager.API"
RUN dotnet build "PreferenceManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PreferenceManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "preferencemanager.dll"]
