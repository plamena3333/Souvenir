using souvenir.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace souvenir.Controller
{
    internal class SouvenirTypeController
    {
        private SouvenirDbContext SouvenirDbContext = new SouvenirDbContext();

        public List<SouvenirType> GetAllSouvenirTypes()
        {
            return SouvenirDbContext.SouvenirTypes.ToList();
        }
        public string GetBreedById(int id)
        {
            return SouvenirDbContext.SouvenirTypes.Find(id).Name;
        }
    }
}
