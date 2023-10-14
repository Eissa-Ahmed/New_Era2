namespace New_Era.Infrastructure.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<InstractorSubject> InstractorSubject { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentConfig(modelBuilder.Entity<Student>());
            new SubjectConfig(modelBuilder.Entity<Subject>());
            new StudentSubjectConfig(modelBuilder.Entity<StudentSubject>());
            new DepartmentConfig(modelBuilder.Entity<Department>());
            new DepartmentSubjectsConfig(modelBuilder.Entity<DepartmentSubject>());
            new InstractorSubjectsConfig(modelBuilder.Entity<InstractorSubject>());
            new InstractorConfig(modelBuilder.Entity<Instructor>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
