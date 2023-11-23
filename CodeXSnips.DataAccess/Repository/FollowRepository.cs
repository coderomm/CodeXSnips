using CodeXSnips.DataAccess.Data;
using CodeXSnips.DataAccess.Repository.IRepository;
using CodeXSnips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository
{
    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        private readonly ApplicationDbContext _db;

        public FollowRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Follow obj)
        {
            _db.Follows.Update(obj);
        }
    }
}
