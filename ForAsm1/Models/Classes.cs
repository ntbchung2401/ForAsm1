using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ForAsm1.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Index("UniqueName", 1, IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}