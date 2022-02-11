FROM node:14-alpine AS build
WORKDIR /app

COPY . .

WORKDIR "/app/WebApp/company-app"

RUN npm install

RUN npm run build --prod

FROM nginx:1.17.1-alpine AS prod-stage
COPY --from=build /app/WebApp/company-app/dist/company-app /usr/share/nginx/html
EXPOSE 80
CMD ["nginx","-g","daemon off;"]
