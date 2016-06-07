﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackEnd
{
    class Document<T>
    {
        T ID;
        BsonDocument content;
        public enum TypeOfOperation {
            PUT,
            PATCH,
            GET,
            POST
        }
        Collection _collection;
        public Document(Collection collection)
        {
            this._collection = collection;
        }
        public bool action(Document<T> document, TypeOfOperation typeOfOperation)
        {
            bool result = true;
            switch(typeOfOperation)
            {
                case TypeOfOperation.GET: return getDocument(document);
                case TypeOfOperation.POST: postDocuemtn(document); break;
            }
            return result;
        }

        private async void postDocuemtn(Document<T> document)
        {
            try
            {
                await _collection.collection.InsertOneAsync(document.content);
            }
            catch
	        {
                throw new Exception("Cannot create new document");
            }
        }

        private bool getDocument(Document<T> document)
        {
            throw new NotImplementedException();
        }
    }
}
