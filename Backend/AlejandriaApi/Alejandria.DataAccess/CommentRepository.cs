using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AlejandriaDbContext _context;

        public CommentRepository(AlejandriaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Comment entity)
        {
            await _context.Set<Comment>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Comment
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Comment>> GetCollection()
        {
            var collecion = await _context.Comments
                .ToListAsync();

            return collecion;
        }

        public async Task<Comment> GetItem(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task Update(Comment entity)
        {
            _context.Set<Comment>().Attach(entity);
            await _context.SaveChangesAsync();
        }
    }
}
