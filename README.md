# Apenas iniciar o container existente
docker start sqlserver

# Aguardar alguns segundos
sleep 10

# Rodar a aplicação
cd /workspaces/DESENVOLVIMENTOSISTEMASAVAN-ADO-I/BibliotecaApp/BibliotecaApp.Web
dotnet run

# Apenas rodar a aplicação direto
cd /workspaces/DESENVOLVIMENTOSISTEMASAVAN-ADO-I/BibliotecaApp/BibliotecaApp.Web
dotnet run



# Criar o container
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SenhaForte123!" \
   -p 1433:1433 --name sqlserver \
   -d mcr.microsoft.com/mssql/server:2022-latest

# Aguardar inicializar
sleep 60

# Aplicar migrations (APENAS na primeira vez)
cd /workspaces/DESENVOLVIMENTOSISTEMASAVAN-ADO-I/BibliotecaApp
dotnet ef database update --project BibliotecaApp.Infrastructure --startup-project BibliotecaApp.Web

# Rodar a aplicação
cd BibliotecaApp.Web
dotnet run