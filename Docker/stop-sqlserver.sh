#!/bin/bash

# Nome do contêiner
CONTAINER_NAME="sqlserver-gameflow"

# Verifica se o contêiner está em execução
CONTAINER_RUNNING=$(docker ps -q -f name=$CONTAINER_NAME)

if [[ -n "$CONTAINER_RUNNING" ]]; then
    echo "Contêiner $CONTAINER_NAME está em execução. Parando o contêiner..."
    docker stop $CONTAINER_NAME
    echo "Contêiner $CONTAINER_NAME parado com sucesso."
else
    echo "Contêiner $CONTAINER_NAME não está em execução."
fi
