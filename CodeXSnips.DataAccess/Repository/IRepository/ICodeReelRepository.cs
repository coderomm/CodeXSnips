using CodeXSnips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository.IRepository
{
    public interface ICodeReelRepository : IRepository<CodeReel>
    {
        void Update(CodeReel obj);
    }
}
