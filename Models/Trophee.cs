using System;
using System.ComponentModel.DataAnnotations;
using Nudge.Models;
using System.Collections.Generic;

namespace Nudge.Models
{
    public class Trophee
    {
        public int Id { get; set; }

        public Personne Personne{get; set;}
        public int PersonneId {get; set;}
        public Defi Defi{get; set;}

        public int DefiId{get;set;}

        public string NomTrophee {get; set;}

    }
}