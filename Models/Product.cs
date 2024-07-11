using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Product
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] //-> usada para especificar como o valor da propriedade Id deve ser armazenado e recuperado do MongoDB
        public string? Id { get; set; }

        [BsonElement("NameColumn")] //-> tipo o column do sql, porem aqui precisamos definir com essa notation
        public string Name { get; set; } = null;
    }
}


/*
  
 >> [BsonId] << -> A anotação [BsonId] é utilizada para indicar que a propriedade marcada será usada como a chave primária do documento no MongoDB.
 No MongoDB, cada documento em uma coleção deve ter uma chave primária única, que é o identificador do documento. 
 Por padrão, se um campo é marcado com [BsonId], o MongoDB usará esse campo como o _id do documento, que é o campo reservado para a chave primária.

 >> [BsonRepresentation(BsonType.ObjectId)] << -> na sua classe Product é usada para especificar como o valor da propriedade Id deve ser armazenado e recuperado do MongoDB.
 No MongoDB, os IDs dos documentos geralmente são do tipo ObjectId, que é um tipo binário específico usado internamente pelo MongoDB para identificar documentos de forma única. No entanto, na sua classe C#, a propriedade Id é uma string.
 A anotação [BsonRepresentation(BsonType.ObjectId)] informa ao driver do MongoDB para converter automaticamente a string Id para um ObjectId quando armazenar no banco de dados, e converter de volta para string quando recuperar do banco de dados. 
 Isso facilita o trabalho com IDs de documentos no MongoDB sem precisar lidar diretamente com o tipo ObjectId no seu código C#.


 >> [BsonElement("NameColumn")] << -> Estou especificando a coluna que sera criada no MongoDb, e tambem especifico o nome dela
 */