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
    public class CodeSnippetRepository(ApplicationDbContext db) : Repository<CodeSnippet>(db), ICodeSnippetRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(CodeSnippet obj)
        {
            _db.CodeSnippets.Update(obj);
        }
    }
}
