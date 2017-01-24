docker rm $(docker ps -a -q --filter=ancestor=corepoker-deploy)
docker build -t corepoker-deploy -f ..\CorePoker.Web\Dockerfile.deploy ..\CorePoker.Web\