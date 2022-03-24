#!/bin/bash
kind load docker-image mongo-express:1.0.0-alpha.4 --name meu-cluster
kind load docker-image mongo:4.4.10 --name meu-cluster
kind load docker-image webapp:1.0.0 --name meu-cluster
kind load docker-image temperatura:1.0.0 --name meu-cluster
kind load docker-image nginx:1.9.4 --name meu-cluster
kind load docker-image rabbitmq:3.9-management --name meu-cluster