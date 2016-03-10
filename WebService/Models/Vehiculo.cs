using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public int Modelo { get; set; }
        public int Kilometraje { get; set; }
    }
}