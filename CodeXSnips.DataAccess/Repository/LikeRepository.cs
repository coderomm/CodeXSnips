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
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        private readonly ApplicationDbContext _db;

        public LikeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Like obj)
        {
            _db.Likes.Update(obj);
        }
    }
}
