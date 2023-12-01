using CodeXSnips.Models;

namespace CodeXSnips.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser obj);

        void Detach(ApplicationUser obj);
    }
}