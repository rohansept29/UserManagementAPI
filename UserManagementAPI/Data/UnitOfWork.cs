using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces;

namespace UserManagementAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public UnitOfWork(DataContext context, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }
        public IUserRepository UserRepository => _userRepository;

        public IAccountRepository AccountRepository => _accountRepository;
    }
}
