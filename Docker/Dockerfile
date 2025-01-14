# Etapa base para configurar timezone, idioma e dependências do sistema
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG TimeZone="America/Cuiaba"
ARG Language="pt_BR"
ARG Unicode="UTF-8"

RUN ln -snf /usr/share/zoneinfo/$TimeZone /etc/localtime && echo $TimeZone > /etc/timezone

RUN apt-get update && \
  apt-get install --no-install-recommends -y tzdata locales locales-all nginx && \
  locale-gen ${Language}.${Unicode} && \
  update-locale LANG=${Language}.${Unicode}

# Etapa de build para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar e restaurar dependências
COPY ["./GameFlow.API/GameFlow.API.csproj", "GameFlow.API/"]
COPY ["./GameFlow.Infrastructure/GameFlow.Infrastructure.csproj", "GameFlow.Infrastructure/"]

RUN dotnet restore "GameFlow.API/GameFlow.API.csproj"

# Copiar o restante do código e compilar o projeto
COPY . .
WORKDIR "GameFlow.API"
RUN dotnet build "GameFlow.API.csproj" -c Release -o /app/build

# Etapa de publicação para gerar os artefatos finais
FROM build AS publish
RUN dotnet publish "GameFlow.API.csproj" -c Release -o /app/publish

# Etapa final: combinar o .NET e configurar o Nginx
FROM base AS final
WORKDIR /app

# Copiar os artefatos publicados
COPY --from=publish /app/publish .

# Configurar Nginx para atuar como proxy reverso
COPY ./Docker/nginx/default.conf /etc/nginx/conf.d/default.conf

# Configuração do Nginx e execução da aplicação
CMD service nginx start && dotnet GameFlow.API.dll
