﻿using LanchesPisci.Models;

namespace LanchesPisci.View_Models
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
