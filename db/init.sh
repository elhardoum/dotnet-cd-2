#!/usr/bin/env bash

for i in {1..60};
do
    echo "initialize db init.sql..."
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -d master -i ./init.sql
    
    if [ $? -eq 0 ]; then
        echo "db setup completed."; break
    else
        echo "db setup pending..."; sleep 1
    fi
done
