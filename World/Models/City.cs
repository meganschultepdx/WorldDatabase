using System;

namespace World.Models
{
  public class City
  {
    public string Country { get; set;}
    public int Population { get; set;}
    public string District { get; set;}


    public City(string country, int population, string district)
    {
      Country = country;
      Population = population;
      District = district;

    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT name FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityCountry = rdr.GetString(2);
        int cityPopulation = rdr.GetInt32(4);
        string cityDistrict = rdr.GetString(3);

        City newCity = new City(cityId, cityCountry, cityPopulation, cityDistrict);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

  }
}
