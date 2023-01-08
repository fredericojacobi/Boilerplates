FROM node:17
WORKDIR /client
EXPOSE 3000
COPY . .
RUN npm install
ENTRYPOINT npm start

# a partir da raiz do projeto
# docker build -t fredericojacobi/client:0.1.0 .