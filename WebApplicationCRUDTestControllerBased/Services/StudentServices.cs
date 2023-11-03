using Microsoft.EntityFrameworkCore;
using WebApplicationCRUDTestControllerBased.AppData;
using WebApplicationCRUDTestControllerBased.Common;
using WebApplicationCRUDTestControllerBased.Models;

namespace WebApplicationCRUDTestControllerBased.Services;


public interface IStudent
{
    Task<GenericHttpResponse<IEnumerable<Student>>> GetAllAsync();
    Task<GenericHttpResponse<Student>> GetByIdAsync(int id);
    Task<GenericHttpResponse<int>> AddAsync(Student student);
    Task<GenericHttpResponse<int>> UpdateAsync(Student student);
    Task<GenericHttpResponse<bool>> DeleteByIdAsync(int id);
}
public class StudentService : IStudent
{
    private readonly AppDbContext _context;
    public StudentService(AppDbContext appDbContext)
    {
        this._context = appDbContext;
    }

    public async Task<GenericHttpResponse<int>> AddAsync(Student student)
    {
        try
        {
            var studentEntity = await _context.Students.AddAsync(student, CancellationToken.None);
            await _context.SaveChangesAsync();
            if (studentEntity.State == EntityState.Added || studentEntity.State==EntityState.Unchanged)
            {
                return new GenericHttpResponse<int>
                {
                    Data = studentEntity.Entity.Id,
                    Message = "Success",
                    Status = true
                };
            }
            else
            {
                return new GenericHttpResponse<int>
                {
                    Data = 0,
                    Message = "Fail",
                    Status = true
                };
            }
        }
        catch (Exception rx)
        {

            return new GenericHttpResponse<int>
            {
                Data = 0,
                Message = rx.Message,
                Status = false
            };
        }

    }

    public async Task<GenericHttpResponse<bool>> DeleteByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();
                return new GenericHttpResponse<bool> { Data = true, Message = "Success", Status = true };
            }
            else
            {
                return new GenericHttpResponse<bool> { Data = false, Message = "Not Found", Status = true };

            }
        }
        catch (Exception ex)
        {
            return new GenericHttpResponse<bool> { Data = false, Message = ex.Message, Status = false };

        }

    }

    public async Task<GenericHttpResponse<IEnumerable<Student>>> GetAllAsync()
    {
        try
        {
            var students = await _context.Students.ToListAsync();
            if (students != null && students.Any())
            {
                return new GenericHttpResponse<IEnumerable<Student>>
                {
                    Data = students,
                    Message = "Success",
                    Status = true
                };
            }
            else
            {
                return new GenericHttpResponse<IEnumerable<Student>>
                {
                    Data = null,
                    Message = "No Record",
                    Status = true
                };
            }
        }
        catch (Exception rx)
        {

            return new GenericHttpResponse<IEnumerable<Student>>
            {
                Data = null,
                Message = rx.Message,
                Status = false
            };
        }
    }

    public async Task<GenericHttpResponse<Student>> GetByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                return new GenericHttpResponse<Student>
                {
                    Data = student,
                    Message = "Success",
                    Status = true
                };
            }
            else
            {
                return new GenericHttpResponse<Student>
                {
                    Data = null,
                    Message = "No Record",
                    Status = true
                };
            }

        }
        catch (Exception ex)
        {
            return new GenericHttpResponse<Student>
            {
                Data = null,
                Message = ex.Message,
                Status = false
            };
        }
    }

    public async Task<GenericHttpResponse<int>> UpdateAsync(Student student)
    {
        try
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            if (student.Id > 0)
            {
                return new GenericHttpResponse<int>
                {
                    Data = student.Id,
                    Message = "Success",
                    Status = true
                };
            }
            else
            {
                return new GenericHttpResponse<int>
                {
                    Data = 0,
                    Message = "No Student Found",
                    Status = true
                };
            }
        }
        catch (Exception rx)
        {

            return new GenericHttpResponse<int>
            {
                Data = 0,
                Message = rx.Message,
                Status = false
            };
        }
    }
}
