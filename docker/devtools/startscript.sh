#!/bin/bash
cd /app/src/ScheduleMeetupConsole
dotnet restore
dotnet run $@