﻿namespace Slide23.Models.ViewModels
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public string ArtikelNaam { get; set; }
        public int Hoeveelheid { get; set; } = 0;

        //public Artikel? Artikels { get; set; }
    }
}
