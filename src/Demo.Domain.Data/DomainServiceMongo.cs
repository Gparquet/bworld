﻿using System;
using System.Threading.Tasks;
using Demo.Data.Tags.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Demo.Data.Mongo;

namespace Demo.Data.Domain
{
    public class DomainServiceMongo : IDomainService
    {
        private readonly IMongoCollection<TagsDbModel> _collection;

        public DomainServiceMongo(IDatabase db)
        {
            var database = db.GetDatabase();

            _collection = database.GetCollection<TagsDbModel>("site.domains");
        }

        public async Task SaveAsync(TagsDbModel tags)
        {
            foreach (var tag in tags.Tags)
            {
                if (string.IsNullOrEmpty(tag.Id))
                {
                    tag.Id = Guid.NewGuid().ToString();
                }
            }

            if (!string.IsNullOrEmpty(tags.Id))
            {
                await _collection.ReplaceOneAsync(new BsonDocument("_id", new Guid(tags.Id)), tags);
            }
            else
            {
                await _collection.InsertOneAsync(tags);
            }
        }

        public async Task<TagsDbModel> FindTags(string siteId, string type)
        {
            var builder = Builders<TagsDbModel>.Filter;
            var filter = builder.Eq(p => p.Type, type) & builder.Eq(p => p.SiteId, siteId);
            return (await _collection.FindAsync(filter)).FirstOrDefault();
        }
    }
}