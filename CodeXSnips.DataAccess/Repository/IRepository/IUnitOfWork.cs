using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICodeReelRepository CodeReel { get; }
        ICodeSnipChatMessageRepository CodeSnipChatMessage { get; }
        ICodeSnippetRepository CodeSnippet { get; }
        ICommentRepository Comment { get; }
        IFollowRepository Follow { get; }
        ILikeRepository Like { get; }
        IStoryRepository Story { get; }
        IUserRepository User { get; }

        void Save();
    }
}
