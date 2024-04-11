using CRUD_Using_One_To_Many_Relationship.Models;

namespace CRUD_Using_One_To_Many_Relationship.Services
{
    public interface IStudent
    {
        Task<Student> Save(Student newstudent);
        Task<List<Student>> GetStudentsList();
        Task<Student> GetStudent(int id);
        Task<Student> Update(Student updatestudent);
        Task<Student> Delete(int id);

    }
}
