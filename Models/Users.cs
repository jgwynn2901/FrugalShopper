using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive.PostgreSQL;

namespace FrugalShopper.Models
{
    public class Users : DynamicModel
    {
        //you don't have to specify the connection - Massive will use the first one it finds in your config
        public Users() : base("shopper", "users", "id") { }

    }

    public class Locations : DynamicModel
    {
        public Locations() : base("shopper", "locations", "id") { }

    }
}