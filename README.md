# Code and assignments for the "Layers, Ports & Adapters" workshop module

## Requirements

- [Docker Engine](https://docs.docker.com/engine/installation/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Getting started

- Clone this repository and `cd` into it.
- Run `docker-compose build`.
- Run `docker-compose up -d` to start the web server.
- Go to [http://localhost:5000/](http://localhost:5000/) in a browser. You should see the homepage of the meetup application.

## Running development tools

- Run `docker-compose run --rm devtools schedule <name> <description> <scheduledfor>` to use the CLI tool for scheduling meetups.
- Run `dotnet restore` and `dotnet test` in test\Meetup to run the tests   