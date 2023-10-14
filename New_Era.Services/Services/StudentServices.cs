namespace New_Era.Services.Services
{
    public class StudentServices : IStudentServices
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Ctor
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        public Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>>? filter = null)
        {
            return _studentRepository.GetAllAsync(filter);
        }

        public Task<Student> GetByIdAsync(int id)
        {
            return _studentRepository.GetByIdAsync(id);
        }
        public async Task<ResponseSwitch> CreateAsync(Student model)
        {
            //Check Name Is Exist
            var NameIsExist = await _studentRepository.GetTableNoTracking()
                .Where(i => i.NameAr.Equals(model.NameAr) || i.NameEn.Equals(model.NameEn)).FirstOrDefaultAsync();
            if (NameIsExist is not null) return ResponseSwitch.NameIsExist;

            //Check Phone Is Exist
            if (!string.IsNullOrEmpty(model.Phone))
            {
                var PhoneIsExist = await _studentRepository.GetTableNoTracking().Where(i => i.Phone.Equals(model.Phone)).FirstOrDefaultAsync();
                if (PhoneIsExist is not null) return ResponseSwitch.PhoneIsExist;
            }

            //Add Student
            await _studentRepository.AddAsync(model);
            return ResponseSwitch.Done;

        }

        public async Task<ResponseSwitch> DeleteAsync(int id)
        {
            //Get Student To Delete
            var student = await _studentRepository.GetTableNoTracking().Where(i => i.Id.Equals(id)).FirstOrDefaultAsync();

            //Check Is Exist
            if (student is null) return ResponseSwitch.DataNotFount;

            //Delete Student
            await _studentRepository.DeleteAsync(student);
            return ResponseSwitch.Done;
        }

        public async Task<ResponseSwitch> UpdateAsync(Student model)
        {
            var StudentTable = _studentRepository.GetTableNoTracking();
            //Check Id Is Valid Or Not
            var studentId = await StudentTable.Where(i => i.Id.Equals(model.Id)).FirstOrDefaultAsync();
            if (studentId is null) return ResponseSwitch.DataNotFount;

            //Check Name Is Exist Or Not
            var studentName = await StudentTable.Where(i => (i.NameAr.Equals(model.NameAr) || i.NameEn.Equals(model.NameEn)) && !i.Id.Equals(model.Id)).FirstOrDefaultAsync();
            if (studentName is not null) return ResponseSwitch.NameIsExist;

            //Check Phone Is Exist Or Not
            if (!string.IsNullOrEmpty(model.Phone))
            {
                var studentPhone = await StudentTable.Where(i => i.Phone.Equals(model.Phone) && !i.Id.Equals(model.Id)).FirstOrDefaultAsync();
                if (studentPhone is not null) return ResponseSwitch.PhoneIsExist;
            }

            //Update Student
            await _studentRepository.UpdateAsync(model);
            return ResponseSwitch.Done;
        }
        public bool IsValid(string text)
        {
            var SplitText = text.Split(" ");
            bool value = false;
            foreach (var item in SplitText)
            {
                value = item.All(char.IsLetter);
            }
            return value;
        }
        public bool ValidPhoneNumber(string phoneNumber)
        {

            foreach (char digit in phoneNumber)
            {
                if (!char.IsDigit(digit))
                    return false;
            }

            return true;
        }

        public IQueryable<Student> GetAllPaginationAsync(string? Search = null)
        {
            if (Search is not null)
            {
                return _studentRepository.GetTableNoTracking().Where(i => i.NameAr.StartsWith(Search) || i.NameEn.StartsWith(Search));
            }
            else
            {
                return _studentRepository.GetTableNoTracking();
            }
        }
    }
}
