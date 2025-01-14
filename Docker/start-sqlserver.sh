#!/bin/bash

# Nome do contêiner
CONTAINER_NAME="sqlserver-gameflow"

# Verifica se o contêiner já existe
CONTAINER_EXISTS=$(docker ps -a -q -f name=$CONTAINER_NAME)

# Se o contêiner existe
if [[ -n "$CONTAINER_EXISTS" ]]; then
    # Verifica se o contêiner está em execução
    CONTAINER_RUNNING=$(docker ps -q -f name=$CONTAINER_NAME)

    if [[ -n "$CONTAINER_RUNNING" ]]; then
        echo "Contêiner $CONTAINER_NAME já está em execução."
    else
        echo "Contêiner $CONTAINER_NAME encontrado, mas está parado. Iniciando o contêiner..."
        docker start $CONTAINER_NAME
        echo "Contêiner $CONTAINER_NAME iniciado com sucesso."
    fi
else
    echo "Subindo o contêiner SQL Server..."

    # Subir o contêiner com SQL Server
    docker run -d \
        --name $CONTAINER_NAME \
        -e 'ACCEPT_EULA=Y' \
        -e 'SA_PASSWORD=YourPassword123' \
        -p 1433:1433 \
        -v sqlserver_data:/var/opt/mssql \
        mcr.microsoft.com/mssql/server:2022-latest

    echo "Contêiner $CONTAINER_NAME subido com sucesso."
fi
