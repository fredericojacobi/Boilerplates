FROM node:17
WORKDIR /client
EXPOSE 3000
COPY . .
RUN npm install
ENTRYPOINT npm start

# docker build -t fredericojacobi/client .