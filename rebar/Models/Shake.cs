﻿using Amazon.Runtime;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rebar.Models
{
    [BsonIgnoreExtraElements]
    public class Shake
    {
        private string _id;

        private string _name;

        private string _description;

        private decimal _priceL;

        private decimal _priceM;

        private decimal _priceS;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Shake( string name, string description, decimal priceL, decimal priceM, decimal priceS)
        {
            _id = new Guid().ToString();
            _name = name;
            _description = description;
            _priceL = priceL;
            _priceM = priceM;
            _priceS = priceS;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _name = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _description = value;
            }
        }

        public decimal PriceL
        {
            get { return _priceL; }
            set
            {
                if (value >= 0)
                    _priceL = value;
            }
        }

        public decimal PriceM
        {
            get { return _priceM; }
            set
            {
                if (value >= 0)
                    _priceM = value;
            }
        }

        public decimal PriceS
        {
            get { return _priceS; }
            set
            {
                if (value >= 0)
                    _priceS = value;
            }
        }

        public decimal getPriceBySize(string size)
        {
            if (size == "Small")
                return this.PriceS;
            if (size == "Medium")
                return this.PriceM;
            if (size == "Large")
                return this.PriceL;
            return 0;
        }
    }


    }
