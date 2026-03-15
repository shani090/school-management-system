builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICollegeContextAccessor, CollegeContextAccessor>();