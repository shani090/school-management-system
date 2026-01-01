Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AuthDbContext -Tables "Colleges","Users" -Force
Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context StudentDbContext -Tables "Colleges","Classes","Students" -Force
Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context TeacherDbContext -Tables "Colleges","Subjects","Teachers" -Force
Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ExamDbContext -Tables "Colleges","Classes","Subjects","Exams","Results" -Force
Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context FeeDbContext -Tables "Colleges","Students","Fees" -Force
Scaffold-DbContext "Name=ConnectionStrings:Default" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context NotificationDbContext -Tables "Colleges","Users","Notifications" -Force

















