FROM mcr.microsoft.com/mssql/server

USER root

RUN apt-get -y update && apt-get install -y dos2unix

ADD db /usr/src/app

RUN dos2unix *

RUN chmod +x /usr/src/app/init.sh

#USER mssql
ENTRYPOINT /bin/bash /usr/src/app/entrypoint.sh
