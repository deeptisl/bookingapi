using BookingApi.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookingSystemContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                var cities = GetCities().ToArray();
                context.City.AddRange(cities);
                context.SaveChanges();

                var drivers = GetDriverDetails().ToArray();
                context.Driver.AddRange(drivers);
                context.SaveChanges();
            }
        }

        public static List<City> GetCities()
        {
            List<City> cities = new List<City>() {
                new City {Country="India",CityName="Bangalore"},
                new City {Country="India",CityName="Pune"},
                new City {Country="India",CityName="Indore"},
                new City {Country="India", CityName="Patna"},
                new City {Country="India",CityName="Chennai"},
                new City {Country="India", CityName="Kolkata"},
                new City {Country="India", CityName="Delhi"},
                new City {Country="India", CityName="Kanpur"},
                new City {Country="India", CityName="Nagpur"},
                new City {Country="India", CityName="Allahabad"}
            };
            return cities;
        }

        public static List<Driver> GetDriverDetails()
        {
            List<Driver> driverDetails = new List<Driver>() {
              new Driver { FirstName="Rahul", LastName="Kumar", Address="Dankuni" },
              new Driver { FirstName="Lokesh", LastName="Kumar", Address="Patna" },
              new Driver { FirstName="Manoj", LastName="Kumar", Address="Bangalore" },
              new Driver { FirstName="Sunny", LastName="Kumar", Address="Delhi" },
              new Driver { FirstName="Sahil", LastName="Kumar", Address="Indore" },
              new Driver { FirstName="Aditya", LastName="Kumar", Address="Mumbay" },
              new Driver { FirstName="Rakesh", LastName="Kumar", Address="Pune" },
              new Driver { FirstName="Munna", LastName="Kumar", Address="Kolkata" }

            };
            return driverDetails;
        }
    }
}
