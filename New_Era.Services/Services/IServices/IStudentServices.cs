namespace New_Era.Services.Services.IServices
{
    public interface IStudentServices
    {
        public Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>>? filter = null);
        public IQueryable<Student> GetAllPaginationAsync(string? Search = null);
        public Task<Student> GetByIdAsync(int id);
        public Task<ResponseSwitch> CreateAsync(Student model);
        public Task<ResponseSwitch> DeleteAsync(int id);
        public Task<ResponseSwitch> UpdateAsync(Student model);
        public bool IsValid(string text);
        public bool ValidPhoneNumber(string phoneNumber);
    }
}
