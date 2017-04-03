FROM microsoft/dotnet:latest

# Expose the port and start the app
EXPOSE 5000
COPY startscript.sh /
RUN chmod 755 /startscript.sh
ENTRYPOINT ["/startscript.sh"]