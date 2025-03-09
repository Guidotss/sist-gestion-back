using Domain.DataSources;

namespace Domain.Repositories;

public abstract class UserRepository
{
    UserRepository(IUserDataSource userDataSource)
    {
        
    }
}