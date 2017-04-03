#!/bin/bash
cd /app
dotnet restore
dotnet run $@