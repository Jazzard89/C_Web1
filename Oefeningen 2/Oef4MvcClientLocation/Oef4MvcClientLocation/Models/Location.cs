using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Oef4MvcClientLocation.CustomModelValidation;
using Oef4MvcClientLocation.Data;
using System.ComponentModel.DataAnnotations;

namespace Oef4MvcClientLocation.Models
{
    public class Location
    {
        public int? LocationId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Dit moet ingevuld zijn!")]
        [CustomPostcode]
        public string? PostCode { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Dit moet ingevuld zijn!")]
        public string? City { get; set; }
        public static List<Location> Locations
        {
            get
            {
                return Database.Locations;
            }
            set
            {
                Database.Locations = value;
            }
        }

        public Location(int? locationId, string? postCode, string? city)
        {
            LocationId = locationId;
            PostCode = postCode;
            City = city;
        }
        public Location() { }
    }
}
