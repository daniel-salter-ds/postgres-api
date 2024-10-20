#!/bin/sh

name=postgres-db

if [ "$(docker ps -aq -f name=$name)" ]; then
    if [ "$(docker ps -aq -f status=running -f name=$name)" ]; then
        echo "$name is already running - no action required"
    else
        echo "$name exists but is not running - starting now"
        docker start $name
    fi
else
    echo "$name does not yet exist - running now"
    docker run --name $name -e POSTGRES_USER=myuser -e POSTGRES_PASSWORD=mypassword -e POSTGRES_DB=mydb -p 5432:5432 -d postgres
fi