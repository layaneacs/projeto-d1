using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using ProjetoD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjetoD1.Data
{
    public class MongoContext
    {
        public IMongoDatabase db { get; }

       
        public string MeuMetodo { get { return "ok"; } }

        

        public MongoContext(IConfiguration settings)
        {            
            try
            {
                var client = new MongoClient(settings.GetSection("ConnectionString").Value);
                db = client.GetDatabase(settings.GetSection("DatabaseName").Value);               
            }
            catch (Exception e)
            {

                throw new MongoException("Não foi possível se conectar no DB - Erro: " + e);
            }
            
        }


        //-- Getts tabelas
        public IMongoCollection<ClienteModel> ClienteDB
        {
            get
            {
                return db.GetCollection<ClienteModel>("dboCliente");
            }
           
        }        
        
    }
}
