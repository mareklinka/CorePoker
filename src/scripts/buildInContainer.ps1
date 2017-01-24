docker rm $(docker ps -a -q --filter=ancestor=corepoker-build)
docker create --name corepoker-build-cont corepoker-build
docker cp corepoker-build-cont:/out/. ../CorePoker.Web/bin/Release/PublishOutput