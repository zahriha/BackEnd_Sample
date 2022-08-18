using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.DAL
{
    public class EnrollmentDAL : IEnrollment
    {
        private readonly DataContext _context;

        public EnrollmentDAL(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteById(int id)
        {
            try
            {
                var enr = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == id);
                if (enr == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Enrollments.Remove(enr);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var enr = await _context.Enrollments.Include(e => e.Student)
                .Include(e => e.Course).AsNoTracking().ToListAsync();
            return enr;
        }

        public async Task<Enrollment> GetById(int id)
        {
            var enr = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == id);
            if (enr == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return enr;
        }

        public async Task<Enrollment> Insert(Enrollment obj)
        {
            try
            {
                _context.Enrollments.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Enrollment> Update(Enrollment obj)
        {
            try
            {
                var up = await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == obj.EnrollmentID);
                if (up == null)
                    throw new Exception($"Data dengan id {obj.EnrollmentID} tidak ditemukan");
                up.CourseID = obj.CourseID;
                up.StudentID = obj.StudentID;
                up.Grade = obj.Grade;
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
