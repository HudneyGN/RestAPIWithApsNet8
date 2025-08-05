using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Model.Context;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace RestAPIWithApsNet8.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;
        public UserRepository(MySqlContext context)
        {
            _context = context;
        }
        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u => 
            (u.UserName == user.UserName) 
            && u.Password == pass);
            // verificar o return _context.users.FirstOrDefault o users do MySqlContext
        }
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] imputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedtBytes = algorithm.ComputeHash(imputBytes);

            var builder = new StringBuilder();

            foreach(var item in hashedtBytes)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
        public bool RevokeToken(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
        public User? ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }
       
    }
}