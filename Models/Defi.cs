using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nudge.Models
{
    public class Defi
    {
        public int Id { get; set; }

        public Personne Personne{get; set;}
        public int PersonneId {get; set;}

        public string Intitule {get; set;}

        public string Commentaire { get; set; }

        public string Theme { get; set; }


        [Required]
        [DataType(DataType.Date)]

        public DateTime DateDebut { get; set; }
        
        [Required]
        [DataType(DataType.Date)]

        public DateTime DateFin { get; set; }

        public int Progression{get; set;}

        public bool Reussite { get; set; }
        
        public bool TousLesJours {get; set;}

        public int Repetition {get; set;}
    }
}