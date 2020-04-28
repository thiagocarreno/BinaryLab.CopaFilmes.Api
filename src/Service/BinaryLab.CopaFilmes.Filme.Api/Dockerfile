#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Service/BinaryLab.CopaFilmes.Filme.Api/BinaryLab.CopaFilmes.Filme.Api.csproj", "Service/BinaryLab.CopaFilmes.Filme.Api/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Configuracao/BinaryLab.CopaFilmes.Configuracao.csproj", "CrossCutting/BinaryLab.CopaFilmes.Configuracao/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Hospedagem/BinaryLab.CopaFilmes.Hospedagem.csproj", "CrossCutting/BinaryLab.CopaFilmes.Hospedagem/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Middleware/BinaryLab.CopaFilmes.Middleware.csproj", "CrossCutting/BinaryLab.CopaFilmes.Middleware/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Http/BinaryLab.CopaFilmes.Http.csproj", "CrossCutting/BinaryLab.CopaFilmes.Http/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Logging/BinaryLab.CopaFilmes.Logging.csproj", "CrossCutting/BinaryLab.CopaFilmes.Logging/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Api/BinaryLab.CopaFilmes.Api.csproj", "CrossCutting/BinaryLab.CopaFilmes.Api/"]
COPY ["Service/BinaryLab.CopaFilmes.Filme.ServicoAplicacao/BinaryLab.CopaFilmes.Filme.ServicoAplicacao.csproj", "Service/BinaryLab.CopaFilmes.Filme.ServicoAplicacao/"]
COPY ["Service/BinaryLab.CopaFilmes.Filme.Repositorio/BinaryLab.CopaFilmes.Filme.Repositorio.csproj", "Service/BinaryLab.CopaFilmes.Filme.Repositorio/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Repositorio.Http/BinaryLab.CopaFilmes.Repositorio.Http.csproj", "CrossCutting/BinaryLab.CopaFilmes.Repositorio.Http/"]
COPY ["CrossCutting/BinaryLab.CopaFilmes.Repositorio/BinaryLab.CopaFilmes.Repositorio.csproj", "CrossCutting/BinaryLab.CopaFilmes.Repositorio/"]
COPY ["Service/BinaryLab.CopaFilmes.Filme.Dominio/BinaryLab.CopaFilmes.Filme.Dominio.csproj", "Service/BinaryLab.CopaFilmes.Filme.Dominio/"]
RUN dotnet restore "Service/BinaryLab.CopaFilmes.Filme.Api/BinaryLab.CopaFilmes.Filme.Api.csproj"
COPY . .
WORKDIR "/src/Service/BinaryLab.CopaFilmes.Filme.Api"
RUN dotnet build "BinaryLab.CopaFilmes.Filme.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BinaryLab.CopaFilmes.Filme.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BinaryLab.CopaFilmes.Filme.Api.dll"]