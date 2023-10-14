namespace New_Era.Services.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentServices(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseSwitch> CreateAsync(Department model)
        {
            //Check Name 
            var DepartmentCheck = await _repository.GetTableNoTracking().Where(i => i.NameAr.Equals(model.NameAr) || i.NameEn.Equals(model.NameEn)).FirstOrDefaultAsync();
            if (DepartmentCheck is not null) return ResponseSwitch.NameIsExist;
            //Add Department
            await _repository.AddAsync(model);
            return ResponseSwitch.Done;
        }

        public async Task<ResponseSwitch> DeleteAsync(int id)
        {
            //Check Department Exist 
            var Department = await _repository.GetTableNoTracking().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();
            if (Department is null) return ResponseSwitch.DataNotFount;

            //Delete Department
            await _repository.DeleteAsync(Department);
            return ResponseSwitch.Done;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var department = await _repository.GetTableNoTracking().Where(i => i.Id.Equals(id))
                .Include(i => i.InstructorManage)
                .Include(i => i.InstructorTech)
                .Include(i => i.DepartmentSubjects).ThenInclude(i => i.Subject).Include(i => i.Student)
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task<ResponseSwitch> UpdateAsync(Department model)
        {
            bool nameArIsExist = await NameIsExist(model.NameAr);
            bool nameEnIsExist = await NameIsExist(model.NameEn);
            if (nameArIsExist || nameEnIsExist) return ResponseSwitch.NameIsExist;
            await _repository.UpdateAsync(model);
            return ResponseSwitch.Done;
        }
        private async Task<bool> NameIsExist(string name)
        {
            var Names = await _repository.GetTableNoTracking().Where(i => i.NameAr.Equals(name) || i.NameEn.Equals(name)).FirstOrDefaultAsync();
            if (Names is null) return false;

            return true;
        }
    }
}
