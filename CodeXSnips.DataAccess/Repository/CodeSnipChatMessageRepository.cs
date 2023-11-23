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
    public class CodeSnipChatMessageRepository : Repository<CodeSnipChatMessage>, ICodeSnipChatMessageRepository
    {
        private ApplicationDbContext _db;

        public CodeSnipChatMessageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CodeSnipChatMessage obj)
        {
            _db.CodeSnipChatMessages.Update(obj);
        }
    }
}
