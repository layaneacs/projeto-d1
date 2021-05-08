using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjetoD1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Models
{
    public class TelefoneModel
    {        
        public string Telefone { get; set; }
        public int Identificador { get; set; } //-- Enum: Comercial, Residencial, outros
    }
}
