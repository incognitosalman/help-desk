# help-desk
Help Desk using ASP.NET Core MVC

# Scaffolding DbContext - Existing Database
dotnet ef dbcontext scaffold --force "Data Source=MALIK\TSQL16;Database=HelpDeskDb;Trusted_Connection=True" Microsoft.EntityFrameworkCore.SqlServer --context HelpDeskContext --namespace Domain.Entities  --output-dir ../Domain/Entities --context-dir ../Infrastructure/Data --context-namespace Infrastructure.Data

> OR 

dotnet ef dbcontext scaffold 
--force 
"Data Source=MALIK\TSQL16;Database=HelpDeskDb;Trusted_Connection=True" 
Microsoft.EntityFrameworkCore.SqlServer 
--context HelpDeskContext 
--context-dir ../Infrastructure/Data 
--context-namespace Infrastructure.Data
--namespace Domain.Entities  
--output-dir ../Domain/Entities 

# Update dotnet-ef tooling
dotnet tool install --global dotnet-ef --version 6.0.5
