#!/bin/bash

echo "Iniciando o build do contêiner GameFlow..."

# Caminho para o Dockerfile e nome da imagem
DOCKERFILE_PATH="Docker/Dockerfile"
IMAGE_NAME="gameflow:latest"

# Executa o build
docker build -f $DOCKERFILE_PATH -t $IMAGE_NAME .

if [ $? -eq 0 ]; then
    echo "Build do contêiner concluído com sucesso!"
else
    echo "Erro durante o build do contêiner!"
    exit 1
fi
