﻿namespace Slide14.Models
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }
        public string AfdelingNaam { get; set; }
        public int LocatieId { get; set; }
        public Locatie? Locatie { get; set; }
    }
}
