﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace souvenir.Model
{
    public class SouvenirType
    {
        public int Id { get; set; } 
          
        public string Name { get; set; } 

        public ICollection<Souvenir> Souvenirs { get; set; }    

        
    }
}
