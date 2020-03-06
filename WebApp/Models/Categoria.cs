﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Categoria
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        
        public virtual IList<Produto> Produtos { get; set; }
    }
}