using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StudentAngular.Data;
using StudentAngular.Models;
using StudentAngular.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAngular.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context) {
            _context = context;
        }

        public Task<bool> Exists(int id)
        {
            return _context.Students.AnyAsync(x => x.Id == id);
        }

        public List<Student> GetAllStudent()
        {
           return _context.Students.ToList();
        }

        public async Task<Student> UpdateStudent(int id, UpdateStudentViewModel student)
        {
            var studentFromDb =  await  _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(studentFromDb != null)
            {
                studentFromDb.Name = student.Name;
                studentFromDb.email = student.email;
                studentFromDb.productInformation = student.productInformation;
                studentFromDb.contactNumber = student.contactNumber;        
                await _context.SaveChangesAsync();
                return studentFromDb;
            }
            return null;
        }

        public async Task<Student> AddStudent(UpdateStudentViewModel student)
        {
            Student model = new Student();
            model.Name = student.Name;
            model.email = student.email;
            model.productInformation = student.productInformation;
            model.contactNumber = student.contactNumber;
            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Student> GetStudentInfo(int id) { 
            return await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> DeleteStudentAsync(int id) {
            var Student = await GetStudentInfo(id);
            if(Student != null)
            {
               _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
                return Student;  
            }
            return null;
        }
    }
}
