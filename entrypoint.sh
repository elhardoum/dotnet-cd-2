#!/usr/bin/env sh

case "$ENVIRONMENT" in
   "dev") dotnet watch run;;
   "development") dotnet watch run;;
   "testing") dotnet test;;
   "test") dotnet test;;
   *) dotnet run;;
esac
