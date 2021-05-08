using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Models
{
    public class EnderecoModel
    {
        public string Endereco { get; set; }

        public int Identificador { get; set; }  //-- Enum: Trabalho, Residencial, outros
    }
}
