using BackEnd.Zahri.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Zahri.DAL
{
    public class CourseDAL : ICourse
    {
        private readonly DataContext _context;

        public CourseDAL(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteById(int id)
        {
            try
            {
                var del = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
                if (del == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Courses.Remove(del);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
            
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var c = await _context.Courses.OrderBy(c => c.Credits).ToListAsync();
            
            return c;
        }

        public async Task<Course> GetById(int id)
        {
            var c = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
            if (c == null)
                throw new Exception($"Data dengan id {id} tidak ditemuka");
            return c;
        }

        public async Task<IEnumerable<Course>> GetByName(string name)
        {
            var c = await _context.Courses.Where(c => c.Title.Contains(name))
                .OrderBy(c => c.Title).ToListAsync();
            return c;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _context.Courses.Add(obj);
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Course> Update(Course obj)
        {
            try
            {
                var up = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == obj.CourseID);
                if (up == null)
                    throw new Exception($"Data dengan id {obj.CourseID} tidak dapat ditemukan");
                up.Title = obj.Title;
                up.Credits = obj.Credits;
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
