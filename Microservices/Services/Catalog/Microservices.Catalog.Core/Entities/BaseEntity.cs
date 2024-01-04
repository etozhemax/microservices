﻿using MongoDB.Bson.Serialization.Attributes;

namespace Microservices.Catalog.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public required string Id { get; set; }
    }
}
