FROM microsoft/dotnet:latest
RUN apt-get -y update && apt-get install -y dos2unix

# Expose the port and start the app
EXPOSE 5000
COPY startscript.sh /
RUN chmod 755 /startscript.sh
RUN dos2unix /startscript.sh
ENTRYPOINT ["/startscript.sh"]