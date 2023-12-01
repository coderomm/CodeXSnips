using CodeXSnips.DataAccess.Data;
using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository
{
    public class UserRepository(ApplicationDbContext db) : Repository<ApplicationUser>(db), IUserRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUsers.Update(obj);
        }

        public void Detach(ApplicationUser entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }
    }
}
