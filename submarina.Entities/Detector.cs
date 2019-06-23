using System;
using System.ComponentModel.DataAnnotations;

namespace submarina.Entities
{
    public class Detector
    {
        public int iddetector { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El código no debe tener más de 10 caracteres")]
        public string code { get; set; }
        [StringLength(256)]
        public string description { get; set; }
        public bool alarm { get; set; }
        public bool trouble { get; set; }
        public bool acknowledged { get; set; }
        [Required]
        public DateTime create_time { get; set; }
        [Required]
        public DateTime update_time { get; set; }
    }
}
