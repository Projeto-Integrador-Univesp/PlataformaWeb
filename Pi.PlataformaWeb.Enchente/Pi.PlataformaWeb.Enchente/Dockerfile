#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Pi.PlataformaWeb.Enchente/Pi.PlataformaWeb.Enchente.csproj", "Pi.PlataformaWeb.Enchente/"]
RUN dotnet restore "Pi.PlataformaWeb.Enchente/Pi.PlataformaWeb.Enchente.csproj"
COPY . .
WORKDIR "/src/Pi.PlataformaWeb.Enchente"
RUN dotnet build "Pi.PlataformaWeb.Enchente.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pi.PlataformaWeb.Enchente.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pi.PlataformaWeb.Enchente.dll"]