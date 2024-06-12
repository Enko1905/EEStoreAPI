﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Şehir tablosu
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string? PlateCode { get; set; }
        public ICollection<CityDistricts> CityDistricts { get; set; }
    }

}
