using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.DAL
{
    public class StudentDAL : IStudent
    {
        private readonly DataContext _context;

        public StudentDAL(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteById(int id)
        {
            try
            {
                var del = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
                if (del == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Students.Remove(del);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            
            var stud = await _context.Students.Include(e => e.Enrollments).OrderBy(s => s.ID).ToListAsync();
            return stud; 
        }

        public async Task<Student> GetById(int id)
        {
            var st = await _context.Students
               .Include(s => s.Enrollments)
               .ThenInclude(e => e.Course)
               .AsNoTracking()
               .FirstOrDefaultAsync(s => s.ID == id);

            if (st == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return st;
        }

       
        public async Task<IEnumerable<Student>> GetStudentC()
        {
            var stu = await _context.Students
               .Include(s => s.Enrollments)
               .ThenInclude(s => s.Course)

               .OrderBy(s => s.ID).AsNoTracking().ToListAsync();

            return stu;
        }


        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            var st = await _context.Students.Where(e => e.FirstName.Contains(name))
                .OrderBy(s => s.FirstName).ToListAsync();
            return st;
        }

        public async Task<Student> Insert(Student obj)
        {
            try
            {
                _context.Students.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Student> Update(Student obj)
        {
            try
            {
                var up = await _context.Students.FirstOrDefaultAsync(s => s.ID == obj.ID);
                if (up == null)
                    throw new Exception($"Data Student dengan id {obj.ID} tidak dapat ditemukan");
                up.FirstName = obj.FirstName;
                up.LastName = obj.LastName;
                up.EnrollmentDate = obj.EnrollmentDate;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

       
    }
}
