dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer ` --output-dir Models ` --context-dir Data ` --context AttendanceDbContext ` --table Colleges --table Students --table Attendance --force

cd "D:\school-management-system\SmartEduHub\AttendanceService"
