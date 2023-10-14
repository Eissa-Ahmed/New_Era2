namespace New_Era.Infrastructure.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> student;
        #endregion

        #region Ctor
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            student = context.students;
        }
        #endregion

        public override async Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>>? filter = null)
        {
            if (filter is not null)
                return await student.Where(filter).Include(i => i.Department).ToListAsync();

            return await student.Include(i => i.Department).ToListAsync();

        }
        public override async Task<Student> GetByIdAsync(int id)
        {
            return await student.Where(i => i.Id.Equals(id)).Include(i => i.Department).FirstOrDefaultAsync();
        }
    }
}
