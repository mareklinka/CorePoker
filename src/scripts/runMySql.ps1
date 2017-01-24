docker rm -f $(docker ps -a -q --filter=name=^/mySqlDb$)
docker run --name mySqlDb -e MYSQL_ROOT_PASSWORD=devel -e MYSQL_ROOT_HOST=172.17.0.1 -p 6603:3306 -d mysql/mysql-server:5.7