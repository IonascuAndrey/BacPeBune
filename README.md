# BacPeBune

BacPeBune este o platforma educationala online, destinata elevilor de liceu ce sustin proba de Bacalaureat la disciplinele Matematica si Informatica.

## Membrii echipei

- [@Andrei Matei-Octavian](https://github.com/matei21)
- [@Bejenaru Ioana](https://github.com/IoanaBejenaru3)
- [@Iacob Alexandru](https://github.com/Alex7586)
- [@Ionascu Andrei](https://github.com/IonascuAndrey)
- [@Vrabie Alexandru](https://github.com/Pacobaba)



# Cerinte proiect

Live demo poate fi gasit [aici](Link YT)

[User Stories + Backlog](https://1drv.ms/w/c/d6c333767dde6822/EdGUJ_rJ2sBNvBSByJyT1R0BrLBUKLfz5hq1qcnPQk0AqQ?e=3VAv5b)

Diagrama ce descrie flow-ul aplicatiei poate fi vazuta [aici](https://github.com/IonascuAndrey/BacPeBune/blob/main/AppFlow.png) iar diagrama E/R a bazei de date [aici](https://github.com/IonascuAndrey/BacPeBune/blob/main/ERDiagram.jpg)

Pentru Source Control am folosit GitHub, iar istoricul commit-urilor se pot vedea [aici](https://github.com/IonascuAndrey/BacPeBune/commits/main/)

Testele automate sunt [aici](Link teste)

Raportare bug-uri si rezolvare cu pull-request am facut, printre altele, la [#5](https://github.com/IonascuAndrey/BacPeBune/issues/5) [#11](https://github.com/IonascuAndrey/BacPeBune/issues/11) [#22](https://github.com/IonascuAndrey/BacPeBune/issues/22) 

Comentariile din cod pot fi vazute in majoritatea fisierelor unde erau necesare clarificari, iar urmarind structura ASP.NET si conventiile C#, am respectat si good code standards.

Am ales ca tehnologie principala pentru backend ASP.NET Core care implementeaza MVC.

Pe partea de prompt engineering, am identificat roluri cheie in dezoltarea aplicatiei, si am folosit modele de LLM pentru a impersona experti in domeniile respective. Prompt-urile pot fi gasite [aici](https://onedrive.live.com/personal/d6c333767dde6822/_layouts/15/doc.aspx?resid=a5a32015-8712-4680-b33c-8931a344b39e&cid=d6c333767dde6822) 





# Technical details for locally running this project
In order to run the application, you need to have Docker Desktop installed (or Docker engine running in general) and run the following commands:

-If you get an error about port 3306, you need to run:
netstat -ano | findstr :3306

Afterwards, you need to enter the specific PID returned as the next parameter
taskkill /PID RETURNED_PROCESS_ID /F

-For Updating the MySql database in a terminal (in the main folder of the project):
docker-compose up -d mysql
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=bacpebune;User=(take user from docker-compose.yml);Password=(take password from docker-compose.yml);Allow User Variables=True;TreatTinyAsBoolean=false"
dotnet ef database update

-Running the app in general (in the main folder of the project)
docker-compose up --build
