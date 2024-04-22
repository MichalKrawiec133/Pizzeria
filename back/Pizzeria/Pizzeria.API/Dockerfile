FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pizzeria.Api/Pizzeria.Api.csproj", "Pizzeria.Api/"]
RUN dotnet restore "Pizzeria.Api/Pizzeria.Api.csproj"
COPY . .
WORKDIR "/src/Pizzeria.Api"
RUN dotnet build "Pizzeria.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizzeria.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizzeria.Api.dll"]
