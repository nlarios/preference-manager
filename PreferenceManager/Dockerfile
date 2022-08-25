FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PreferenceManager/PreferenceManager.csproj", "PreferenceManager/"]
RUN dotnet restore "PreferenceManager/PreferenceManager.csproj"
COPY . .
WORKDIR "/src/PreferenceManager"
RUN dotnet build "PreferenceManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PreferenceManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PreferenceManager.dll"]
