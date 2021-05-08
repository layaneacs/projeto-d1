using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Models
{
    public class ClienteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Nome { get; set; }

        [BsonRequired]
        public DateTime DataNascimento { get; set; }
        public List<TelefoneModel> Telefones { get; set; }
        public List<EnderecoModel> Enderecos { get; set; }
        public List<SocialModel> RedesSociais { get; set; }

        [BsonRequired]
        public string CPF { get; set; }
        public string RG { get; set; }
    }
}
