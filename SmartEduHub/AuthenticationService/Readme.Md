dotnet ef dbcontext scaffold "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context AuthDbContext --table Colleges --table Users --RefreshTokens --RevokedTokens --force

cd "D:\school-management-system\SmartEduHub\AuthenticationService"