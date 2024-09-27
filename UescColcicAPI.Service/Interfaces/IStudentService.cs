using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    Task<Student> CreateStudentAsync(Student student);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(int studentId);
}