using StudentAngular.Models;
using StudentAngular.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAngular.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudent();

        Task<bool> Exists(int id);

        Task<Student> GetStudentInfo(int id);

        Task<Student> UpdateStudent(int id, UpdateStudentViewModel student);

        Task<Student> AddStudent(UpdateStudentViewModel student);

        Task<Student> DeleteStudentAsync(int id);
    }
}
