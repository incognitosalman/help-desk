# help-desk
Help Desk using ASP.NET Core MVC


dotnet ef dbcontext scaffold --force "Data Source=MALIK\TSQL16;Database=HelpDeskDb;Trusted_Connection=True" Microsoft.EntityFrameworkCore.SqlServer --context HelpDeskContext --namespace Domain.Entities  --output-dir ../Domain/Entities --context-dir ../Infrastructure/Data --context-namespace Infrastructure.Data
