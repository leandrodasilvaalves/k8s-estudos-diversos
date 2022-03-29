continuar aqui: https://kubedev.club.hotmart.com/lesson/94JMJqznOg/subindo-a-aplicacao

# Carregar imagem do docker local para o cluster kind
kind load docker-image webapp:1.0.0 --name meu-cluster

# Configurar Kluster
sudo usermod -a -G microk8s ubuntu
sudo chmod -f -R ubuntu ~/.kube
# reboot vm

/snap/bin/microk8s.kubectl config view --raw


microk8s add-node
From the node you wish to join to this cluster, run the following:
microk8s join 10.0.0.121:25000/a40c376555ee8b7ecf69163c46a78c2f/21da4c35b7a0

Use the '--worker' flag to join a node as a worker not running the control plane, eg:
microk8s join 10.0.0.121:25000/a40c376555ee8b7ecf69163c46a78c2f/21da4c35b7a0 --worker

If the node you are adding is not reachable through the default interface you can use one of the following:
microk8s join 10.0.0.121:25000/a40c376555ee8b7ecf69163c46a78c2f/21da4c35b7a0
microk8s join 172.17.0.1:25000/a40c376555ee8b7ecf69163c46a78c2f/21da4c35b7a


kubectl create namespace blue
kubectl apply -f deployment.yaml -n blue
kubectl get deployments -n blue
kubectl get pods --all-namespaces -o wide

http://nomeservico.svc.cluster.local
Exemplo: curl http://service-nginx-color.blue.svc.cluster.local

Criar service do tipo external-name no namespace default

exemplo:
``` 
apiVersion: v1
kind: Service
metadata:
  name: service-nginx-blue
spec:
  type: ExternalName
  externalName: service-nginx-color.blue.svc.cluster.local
``` 
`curl http://service-nginx-blue`

#para saber quais recursos são separáveis por namespace
kubectl api-resources --namespaced=true

#Ingress Controller
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.1.2/deploy/static/provider/cloud/deploy.yaml