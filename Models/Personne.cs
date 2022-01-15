using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nudge.Models
{
    public class Personne
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom {get; set;}

        public string LienPhoto{get; set;}

        public string AdresseMail {get; set;}

        public string NumTel{get; set;}

        public List<Defi> ListeDefi {get; set;}

        public List<Trophee> ListeTrophee {get; set;}


    }
}