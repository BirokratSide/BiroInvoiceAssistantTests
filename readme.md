## BiroInvoiceAssistantTests

THIS PROJECT WAS MOVED. NOW ALL PROJECTS THAT ARE DEPENDENCIES OF BIROINVOICEASSISTANT ARE IN ONE REPOSITORY. THIS IS KEPT TO PRESERVE THE GIT HISTORY OF THE TESTS PROJECT.

### Dependencies

- .net core framework 2.1

### Troubleshooting

- A likely cause of failure is the mismatch between the current database and the EntityFramework scaffolded database context. These tests are NOT usable on the production database. The reason is that the entity framework scaffolds need an additional primary key constraint on the needed tables.
Here is the solution on non-production databases.

#### database scaffolding problem
- make sure you are using .net core framework 2.1
- Use the nuget package manager console
    - ```Install-Package Microsoft.EntityFrameworkCore.SqlServer```
    - ```Install-Package Microsoft.EntityFrameworkCore.Tools```
    - ```Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design```
- perform database alterations on all of the tables that you want to scaffold
    - ```alter table Tabela add primary key (RecNo);```
- scaffold all of the tables within Visual Studio.
    - First scaffold the biro database models
        - ```Scaffold-DbContext "Server=192.168.0.126;Database=biro16010264;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t PostnaKnjiga, Slike```
    - Then scaffold the ones from biroside databse
        - ```Scaffold-DbContext "Server=192.168.0.126;Database=biroside;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models1 -t InvoiceBuffer, BufferHistoryLog```

