using System;
using System.Collections.Generic;
using System.Linq;

namespace MiddlewareWeb.Data
{
    public class TrabajosRepo
    {
        private ProyectoEntities db = new ProyectoEntities();

        public TrabajosRepo()
        {
        }

        public IEnumerable<Trabajo> Get()
        {
            return db.Trabajos.OrderByDescending(t => t.ID).ToList();
        }
        public void Insert(Trabajo trabajo)
        {
            db.Trabajos.Add(trabajo);
        }
        public void Save()
        {
            try
            {
                db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}