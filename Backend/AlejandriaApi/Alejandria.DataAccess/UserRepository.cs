﻿using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alejandria.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AlejandriaDbContext _context;

        public UserRepository(AlejandriaDbContext context)
        {
            _context = context;
        }


        public void Create(User entity)
        {
            _context.Set<User>().Add(entity);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Entry(new User
            {
                Id = id

            }).State = EntityState.Deleted;

            _context.SaveChanges();
        }

        public ICollection<User> GetCollection(string filter)
        {
            return _context.Users
                .Where(c => c.Name.Contains(filter))
                .ToList();
        }

        public User GetItem(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User entity)
        {
            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
