#!/bin/bash

echo "Iniciando o servidor GameFlow com Docker..."

# Nome da imagem e do contêiner
IMAGE_NAME="gameflow:latest"
CONTAINER_NAME="gameflow-server"
PORT=80

# Verifica se o contêiner já existe
if [ "$(docker ps -aq -f name=$CONTAINER_NAME)" ]; then
    # Verifica se o contêiner está em execução
    if [ "$(docker ps -q -f name=$CONTAINER_NAME)" ]; then
        echo "O contêiner $CONTAINER_NAME já está em execução."
    else
        echo "Iniciando o contêiner existente $CONTAINER_NAME..."
        docker start $CONTAINER_NAME
        if [ $? -eq 0 ]; then
            echo "Contêiner iniciado com sucesso!"
        else
            echo "Erro ao iniciar o contêiner!"
            exit 1
        fi
    fi
else
    # Cria e inicia o contêiner
    echo "Criando e iniciando o contêiner $CONTAINER_NAME..."
    docker run -d -p $PORT:80 --name $CONTAINER_NAME $IMAGE_NAME
    if [ $? -eq 0 ]; then
        echo "Contêiner criado e iniciado com sucesso!"
    else
        echo "Erro ao criar o contêiner!"
        exit 1
    fi
fi
