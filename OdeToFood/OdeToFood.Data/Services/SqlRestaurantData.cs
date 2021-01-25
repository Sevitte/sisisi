using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id ==id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   join o in db.Owners on r.OwnerId equals o.Id
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //this is an object already existing in db-> track it
            var entry = db.Entry(restaurant);
            //it was changed 
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}
