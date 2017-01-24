FROM microsoft/aspnetcore
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000/tcp

COPY ./bin/Release/PublishOutput/out /app

WORKDIR /app

CMD ["dotnet", "app.dll"]
