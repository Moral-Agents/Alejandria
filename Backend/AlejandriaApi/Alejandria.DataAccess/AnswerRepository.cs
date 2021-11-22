using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alejandria.DataAccess
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AlejandriaDbContext _context;

        public AnswerRepository(AlejandriaDbContext context)
        {
            _context = context;
        }

        public async Task Create(Answer entity)
        {
            await _context.Set<Answer>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Answer
            {
                Id = id
            }).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Answer>> GetCollection()
        {
            var collecion = await _context.Answers
                .ToListAsync();

            return collecion;
        }

        public async Task<Answer> GetItem(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task Update(Answer entity)
        {
            _context.Set<Answer>().Attach(entity);
            await _context.SaveChangesAsync();
        }
    }
}
