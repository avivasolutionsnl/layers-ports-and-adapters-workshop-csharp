FROM microsoft/dotnet:latest

# Create directory for the app source code
RUN mkdir -p /app
WORKDIR /app

# Copy the source and restore dependencies
COPY ./src/Web /app
RUN dotnet restore

RUN dotnet add package Microsoft.DotNet.Watcher.Tools

# Expose the port and start the app
EXPOSE 5000
COPY startscript.sh /
RUN chmod 755 /startscript.sh
ENTRYPOINT ["/startscript.sh"]