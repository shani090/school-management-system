dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer `--output-dir Models `--context-dir Data `--context UserDbContext `--table Colleges `--table Users `--table RefreshTokens `--table RevokedTokens `--force
cd "D:\school-management-system\SmartEduHub\UserManagementService"

