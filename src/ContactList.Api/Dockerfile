FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ContactList.Api/ContactList.Api.csproj", "src/ContactList.Api/"]
COPY ["src/ContactList.Dal/ContactList.Dal.csproj", "src/ContactList.Dal/"]
COPY ["src/ContactList.Domain/ContactList.Domain.csproj", "src/ContactList.Domain/"]
COPY ["src/ContactList.Bll/ContactList.Bll.csproj", "src/ContactList.Bll/"]
RUN dotnet restore "src/ContactList.Api/ContactList.Api.csproj"
COPY . .
WORKDIR "/src/src/ContactList.Api"
RUN dotnet build "ContactList.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ContactList.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactList.Api.dll"]
