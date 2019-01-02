docker run -it --rm --name docker-nginx -p 80:80 -v /home/bryan/Git/MySiteDockerFiles/docker-nginx/html:/usr/share/nginx/html nginx


docker run -it --rm --name docker-nginx -p 80:80 -v /home/bryan/Git/MySiteDockerFiles/docker-nginx/html:/usr/share/nginx/html -v /home/bryan/Git/MySiteDockerFiles/default.conf:/etc/nginx/conf.d/default.conf nginx

docker run -it --rm --name docker-nginx2 -p 80:80 -v /Users/bmccoy/Git/CoreBlogger/src/Docker/default.conf:/etc/nginx/conf.d/default.conf nginx

docker cp docker-nginx:/etc/nginx/conf.d/default.conf default.conf


docker cp docker-nginx:/etc/nginx/conf.d/default.conf default.conf