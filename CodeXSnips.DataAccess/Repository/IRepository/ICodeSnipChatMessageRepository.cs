using CodeXSnips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository.IRepository
{
    public interface ICodeSnipChatMessageRepository : IRepository<CodeSnipChatMessage>
    {
        void Update(CodeSnipChatMessage obj);
    }
}
