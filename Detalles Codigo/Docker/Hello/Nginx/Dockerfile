FROM nginx:latest

# Copy virtual hosts config
RUN rm /etc/nginx/conf.d/default.conf
COPY ./hello.com.config /etc/nginx/conf.d/