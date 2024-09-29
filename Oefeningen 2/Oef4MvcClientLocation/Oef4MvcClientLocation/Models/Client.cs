using MessagePack;
using Microsoft.Build.Framework;
using Oef4MvcClientLocation.Data;
using System.ComponentModel.DataAnnotations;
using Oef4MvcClientLocation.CustomModelValidation;
using System;

namespace Oef4MvcClientLocation.Models
{
    public class Client
    {
        [ClientId]
        public int? ClientId { get; set; }
        public int? LocationId { get; set; }
        [CustomNoNumbers]
        public string? ClientName { get; set; }
        public static List<Client> Clients 
        {
            get
            {
                return Database.Clients;
            }
            set
            {
                Database.Clients = value;
            }
        }

        public Client(int? clientId, int? locationId, string? clientName)
        {
            ClientId = clientId;
            LocationId = locationId;
            ClientName = clientName;
        }
        public Client() { }
    }
}
