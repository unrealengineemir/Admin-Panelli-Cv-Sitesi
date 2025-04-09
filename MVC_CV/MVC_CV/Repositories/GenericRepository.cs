using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MVC_CV.Models.Entity;


namespace MVC_CV.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        CvDatabaseEntities db = new CvDatabaseEntities();

        public List<T> List()
        {

            return db.Set<T>().ToList();



        }

        public void Tadd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();


        }

        public void Tdelete(T p)
        {

            db.Set<T>().Remove(p);
            db.SaveChanges();

        }

        public T Find(int id)
        {

            return db.Set<T>().Find(id);


        }

        public void Tupdate(T p)
        {

            db.SaveChanges();
        }


        public T IFind(Expression<Func<T,bool>> where)
        {

            return db.Set<T>().FirstOrDefault(where);

        }



    }
}