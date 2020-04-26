FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BinaryLab.CopaFilmes.Filme.Api/BinaryLab.CopaFilmes.Filme.Api.csproj", "BinaryLab.CopaFilmes.Filme.Api/"]
RUN dotnet restore "BinaryLab.CopaFilmes.Filme.Api/BinaryLab.CopaFilmes.Filme.Api.csproj"
COPY . .
WORKDIR "/src/BinaryLab.CopaFilmes.Filme.Api"
RUN dotnet build "BinaryLab.CopaFilmes.Filme.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BinaryLab.CopaFilmes.Filme.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BinaryLab.CopaFilmes.Filme.Api.dll"]