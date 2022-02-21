FROM mcr.microsoft.com/dotnet/sdk:3.1

COPY . /usr/src/app
WORKDIR /usr/src/app

RUN dotnet restore
RUN dotnet build

ENTRYPOINT sh /usr/src/app/entrypoint.sh