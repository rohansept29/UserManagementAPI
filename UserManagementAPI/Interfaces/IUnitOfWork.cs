namespace UserManagementAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}
