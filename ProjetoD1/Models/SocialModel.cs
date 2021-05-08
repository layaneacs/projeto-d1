using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Models
{
    public class SocialModel
    {
        public string URL { get; set; }
        public int Identificador { get; set; }  //-- Enum: Facebook, Linkedin, Twitter, Instagram
    }
}
