namespace New_Era.Model.AppRouter
{
    public static class Router
    {
        private const string Api = "api/";
        public static class StudentRouter
        {
            private const string Base = Api + "Student/";
            public const string GetAllAsync = Base + "GetAllStudent";
            public const string GetByIdAsync = Base + "GetByIdAsync";
            public const string CreateAsync = Base + "CreateAsync";
            public const string DeleteAsync = Base + "DeleteAsync";
            public const string UpdateAsync = Base + "UpdateAsync";
            public const string GetAllAsyncPagination = Base + "GetAllAsyncPagination";
        }
        public static class DepartmentRouter
        {
            private const string Base = Api + "Department/";
            public const string GetAllAsync = Base + "GetAllDepartment";
            public const string GetByIdAsync = Base + "GetByIdAsync";
            public const string CreateAsync = Base + "CreateAsync";
            public const string DeleteAsync = Base + "DeleteAsync";
            public const string UpdateAsync = Base + "UpdateAsync";
        }
    }
}
