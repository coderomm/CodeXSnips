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
    public class StoryRepository : Repository<Story>, IStoryRepository
    {
        private readonly ApplicationDbContext _db;

        public StoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Story obj)
        {
            _db.Stories.Update(obj);
        }
    }
}
