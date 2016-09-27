using MyApp.Core.Data;
using MyApp.Core.Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Entities;
using MyApp.Infrastructure.Repositories;
using System.Data.Entity.Validation;

namespace MyApp.Infrastructure
{
   
        public class UnitOfWork : IDisposable
        {
            private MyAppDbContext _context = null;
            private GenericRepository<Student> _studentRepository;

            public UnitOfWork()
            {
                _context = new MyAppDbContext();
            }


            public GenericRepository<Student> StudentRepository
            {
                get
                {
                    if (this._studentRepository == null)
                        this._studentRepository = new GenericRepository<Student>(_context);
                    return _studentRepository;
                }
            }


            public void Save()
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    throw e;
                }

            }

            private bool disposed = false;
 
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }


    
}
