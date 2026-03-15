dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer `--output-dir Models ` --context-dir Data `--context TeacherDbContext `--tables Colleges,Subjects,Teachers `--force


cd "D:\school-management-system\SmartEduHub\TeacherService"