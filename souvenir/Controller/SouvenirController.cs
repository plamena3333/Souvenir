using souvenir.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace souvenir.Controller
{
    internal class SouvenirController
    {

        private SouvenirDbContext _myDbContext = new SouvenirDbContext ();

        public Souvenir Get(int id)
    {
         Souvenir findedSouvenir_ = _myDbContext.Souvenirs.Find(id);
         if (findedSouvenir_ !=null)
         {
            _myDbContext.Entry(findedSouvenir_).Reference(x => x.SouvenirTypes).Load();
         }
             return findedSouvenir_;
         }
        public List<Souvenir> GetAll()
        {
         return _myDbContext.Souvenirs.Include("SouvenirTypes").ToList();
        }
        public void Create(Souvenir souvenir)
        {
         _myDbContext.Souvenirs.Add(souvenir);
         _myDbContext.SaveChanges();
        }

         public void Update(int id, Souvenir souvenir)
         {
            Souvenir findedSouvenir = _myDbContext.Souvenirs.Find(id);
            if (findedSouvenir==null) 
            {
               return;
            }
              findedSouvenir.Name = souvenir.Name;
              findedSouvenir.Price = souvenir.Price;
              findedSouvenir.SouvenirTypeId = souvenir.SouvenirTypeId;
              _myDbContext.SaveChanges();
         }

         public void Delete(int id)
         {
            Souvenir findedSouvenir_ = _myDbContext.Souvenirs.Find(id);
            _myDbContext.Souvenirs.Remove(findedSouvenir_);
            _myDbContext.SaveChanges();
         }
    }
}
