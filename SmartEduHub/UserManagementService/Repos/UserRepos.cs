using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Data;
using UserManagementService.Dtos;
using UserManagementService.Models;

namespace UserManagementService.Repos
{
    public class UserRepos
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;
        public UserRepos(UserDbContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        
        }
        public async Task<RegisterResponsedto> Register(RegisterDto objReg, int _tanentID)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var Entity = _mapper.Map<User>(objReg);
                //Entity.TenantId = _tanentID;

                if (await _context.Users.AnyAsync(u => u.Phone == Entity.Phone))
                {
                    return new RegisterResponsedto { Message = "PhoneNumber already exists" };
                }
                if (await _context.Users.AnyAsync(u => u.Email == Entity.Email))
                {
                    return new RegisterResponsedto { Message = "Email already exists" };
                }
                if (Entity.PasswordHash.Length < 6)
                {
                    return new RegisterResponsedto { Message = "Password must be at least 6 characters long" };
                }
                if (!Entity.PasswordHash.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    return new RegisterResponsedto { Message = "Password must contain at least one special character" };
                }
                Entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Entity.PasswordHash);
                Entity.Role = Entity.Role?.ToLower();

                _context.Users.Add(Entity);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new RegisterResponsedto
                {
                    //Id = Entity.Id,
                    Message = "User registered successfully"
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
            finally
            {

                await transaction.DisposeAsync();
            }
        }


    }
    public class RegisterResponsedto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
