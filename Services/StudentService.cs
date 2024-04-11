using CRUD_Using_One_To_Many_Relationship.Context;
using CRUD_Using_One_To_Many_Relationship.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Using_One_To_Many_Relationship.Services
{
    public class StudentService : IStudent
    {
        private AppDBContext ctx;

        public StudentService(AppDBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Student> Delete(int id)
        {
            if(id==null)
            {
                throw new Exception();
            }
            Student student=await GetStudent(id);
            ctx.Students.Remove(student);
            ctx.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudent(int id)
        {
            Student student = await ctx.Students.Include(val => val.Department).Where(val => val.Sno == id).FirstOrDefaultAsync();
            if(student==null)
            {
                throw new Exception();
            }
            return student;
        }

        private List<Student> students;
        public async Task<List<Student>> GetStudentsList()
        {

            await Task.Run(() =>
            {
                students = ctx.Students.ToList();
            });
            return students;
        }

        public async Task<Student> Save(Student newstudent)
        {
            if(newstudent==null)
            {
                throw new Exception();
            }
            ctx.Students.Add(newstudent);
            await ctx.SaveChangesAsync();
            return newstudent;
        }

        public async Task<Student> Update(Student updatestudent)
        {
            if(updatestudent==null)
            {
                throw new Exception();
            }
            ctx.Students.Update(updatestudent);
            await ctx.SaveChangesAsync();   
            return updatestudent;
        }
    }
}
