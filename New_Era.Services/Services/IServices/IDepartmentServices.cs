namespace New_Era.Services.Services.IServices
{
    public interface IDepartmentServices
    {
        public Task<IEnumerable<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<ResponseSwitch> DeleteAsync(int id);
        public Task<ResponseSwitch> UpdateAsync(Department model);
        public Task<ResponseSwitch> CreateAsync(Department model);
    }
}
