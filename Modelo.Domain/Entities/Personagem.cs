﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Entities
{
   public class Personagem
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }

        public string School { get; set; }

        public string House { get; set; }

        public string Patronus { get; set; }

        public DateTime CreateAt { get; set; }
     

    }
}
