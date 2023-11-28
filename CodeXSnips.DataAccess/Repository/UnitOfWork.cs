using CodeXSnips.DataAccess.Data;
using CodeXSnips.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICodeReelRepository CodeReel { get; private set; }
        public ICodeSnipChatMessageRepository CodeSnipChatMessage { get; private set; }
        public ICodeSnippetRepository CodeSnippet { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public IFollowRepository Follow { get; private set; }
        public ILikeRepository Like { get; private set; }
        public IStoryRepository Story { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CodeReel = new CodeReelRepository(_db);
            CodeSnipChatMessage = new CodeSnipChatMessageRepository(_db);
            CodeSnippet = new CodeSnippetRepository(_db);
            Comment = new CommentRepository(_db);
            Follow = new FollowRepository(_db);
            Like = new LikeRepository(_db);
            Story = new StoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
