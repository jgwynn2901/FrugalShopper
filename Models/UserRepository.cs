using System;
using System.Linq;

using System.Collections.Generic;

namespace FrugalShopper.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FormattedAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class UserRepository
    {
        public static List<User> All()
        {
            return new Users()
                .All()
                .Select(a => new User 
                    { 
                       Id = a.id, 
                       UserName = a.user_name, 
                       Password = a.password, 
                       EmailAddress = a.email_address 
                    }).ToList();

        }

        public static List<Location> Locations(int id)
        {

            dynamic table = new Locations();
            var locations = table.Find(user_id: id);
            var results = new List<Location>();

            foreach (var item in locations)
            {
                results.Add(new Location
                    {
                        Id = item.id,
                        UserId = item.user_id,
                        FormattedAddress = item.formatted_address,
                        Latitude = item.latitude,
                        Longitude = item.longitude
                    });
            }
            return results;
        }

        public static int Insert(Location location)
        {
            dynamic table = new Locations();
            var locations = table.Find(user_id: location.UserId, formatted_address: location.FormattedAddress);
            foreach (var item in locations)
            {
                table.Update(new { formatted_address = location.FormattedAddress }, item.id);
                return item.id;
            }
            // do it up - the new ID will be returned from the query
            var results = table.Insert(new
            {
                user_id = location.UserId,
                formatted_address = location.FormattedAddress,
                latitude = location.Latitude,
                longitude = location.Longitude
            });

            return 1;
        }
    }
}