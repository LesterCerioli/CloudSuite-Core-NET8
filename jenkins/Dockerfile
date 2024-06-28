# Usar a imagem base do Jenkins com JDK 17
FROM jenkins/jenkins:2.452.2-jdk17

# Mudar para o usuário root para instalar pacotes
USER root

# Atualizar a lista de pacotes e instalar lsb-release
RUN apt-get update && apt-get install -y lsb-release

# Adicionar a chave GPG para o repositório Docker
RUN curl -fsSLo /usr/share/keyrings/docker-archive-keyring.asc https://download.docker.com/linux/debian/gpg

# Adicionar o repositório Docker à lista de fontes do apt
RUN echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.asc] https://download.docker.com/linux/debian $(lsb_release -cs) stable" > /etc/apt/sources.list.d/docker.list

# Atualizar a lista de pacotes e instalar Docker CLI
RUN apt-get update && apt-get install -y docker-ce-cli

# Copiar o script Groovy para configurar o administrador
COPY init.groovy.d /var/jenkins_home/init.groovy.d

# Configurar permissões para o diretório Jenkins
RUN chown -R jenkins:jenkins /var/jenkins_home && \
    chmod -R 755 /var/jenkins_home

# Voltar para o usuário Jenkins
USER jenkins

# Instalar plugins Jenkins necessários
RUN jenkins-plugin-cli --plugins "blueocean docker-workflow azure-credentials azure-vm-agents azure-app-service azure-artifact-manager"

# Expor a porta 8080
EXPOSE 8080

# Criar um volume para o diretório inicial
VOLUME /var/jenkins_home
