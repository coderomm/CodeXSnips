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
    public class CodeReelRepository(ApplicationDbContext db) : Repository<CodeReel>(db), ICodeReelRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(CodeReel obj)
        {
            _db.CodeReels.Update(obj);
        }
    }
}
