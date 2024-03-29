﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace Webassistenten_ads_api.Models
{
    [System.Runtime.Serialization.KnownType(typeof(Modul))]
    public class DataModel
    {
        public int productId { get; private set; }
        WebAssistentAuth auth;
        public DataModel(int productId)
        {
            this.productId = productId;
        }

        public DataModel()
        {
            auth = new WebAssistentAuth();
        }

        public void checkMail(string email)
        {
            auth.EmailAuthenticate(email);
        }

        public void checkId(int id)
        {
            auth.IdAuthenticate(id);
        }

        public byte getId()
        {
            return (byte)auth.AuthId;
        }
        public IEnumerable<ProduktUtgivelse> GetDate()
        {
            return DatabaseConnection.GetNextFivePublishables((byte)productId);
        }

        public IEnumerable<Produkt> GetProducts(byte partnerID)
        {
            return DatabaseConnection.GetProducts(partnerID);
        }

        public IEnumerable<Modul> GetProductModules()
        {
            return (IEnumerable<Modul>)DatabaseConnection.GetProductModules((byte)productId).AsEnumerable();

        }

        public Array GetProductModulesArray()
        {
            return DatabaseConnection.GetProductModules((byte)productId).ToArray();

        }
    }
    
}