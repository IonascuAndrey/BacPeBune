# BacPeBune
A learning platform for Romanian students.

In order to run the application, you need to have Docker Desktop installed (or Docker engine running in general) and run the following commands:

-For Updating the MySql database in a terminal (in the main folder of the project):
docker-compose up -d mysql
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=bacpebune;User=(take user from docker-compose.yml);Password=(take password from docker-compose.yml);Allow User Variables=True;TreatTinyAsBoolean=false"
dotnet ef database update

-Running the app in general (in the main folder of the project)
docker-compose up --build
