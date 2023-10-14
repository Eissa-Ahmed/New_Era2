namespace New_Era.Infrastructure.Repository
{
    public class InstractorRepository : GenericRepository<Instructor>, IInstractorRepository
    {
        public InstractorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
