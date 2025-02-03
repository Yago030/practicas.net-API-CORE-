namespace StudentSubjectAPI.Repositories
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context )
        {
            _context = context;
        }
            
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

    }
}
