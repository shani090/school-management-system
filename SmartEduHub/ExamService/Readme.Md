dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer `--output-dir Models `--context-dir Data ` --context ExamDbContext ` --table Students ` --table Classes ` --table Colleges ` --table Exams ` --table Results ` --table Subjects ` --force ` --framework net8.0

cd "D:\school-management-system\SmartEduHub\ExamService"

