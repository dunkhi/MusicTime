using MusicTime.Data;
using MusicTime.Domain;
using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
  public class Program
  {
    MusicTimeContext _context;
    static void Main(string[] args)
    {
      var _context = new MusicTimeContext();
      var artist = _context.Artists.Where(a => a.Id == 1).First();
      Console.WriteLine($"Artist Name before update {artist.FullName}");
      artist.FirstName = "Herman";
      artist.LastName = "Giambi";
      _context.SaveChanges();
      Console.WriteLine($"Artist Name after changing {artist.FullName}");
    }

    private static void InsertCountriesRegions()
    {
      var context = new MusicTimeContext();
      //var countries = new List<Country>
      //{
      //  new Country {
      //              Iso3 = "USA",
      //              CountryNameEnglish = "United States of America"
      //          },
      //          new Country
      //          {
      //              Iso3 = "CAN",
      //              CountryNameEnglish = "Canada"
      //          },
      //          new Country
      //          {
      //              Iso3 = "FRA",
      //              CountryNameEnglish = "France"
      //          }
      //};
      //foreach (var c in countries)
      //{
      //  context.Countries.Add(c);
      //}
      //context.SaveChanges();

      var regions = new List<Region>
            {
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AL",
                    RegionNameEnglish = "Alabama"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AK",
                    RegionNameEnglish = "Alaska"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AZ",
                    RegionNameEnglish = "Arizona"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AR",
                    RegionNameEnglish = "Arkansas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CA",
                    RegionNameEnglish = "California"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CO",
                    RegionNameEnglish = "Colorado"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CT",
                    RegionNameEnglish = "Connecticut"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "DC",
                    RegionNameEnglish = "District of Columbia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "DE",
                    RegionNameEnglish = "Delaware"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "FL",
                    RegionNameEnglish = "Florida"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "GA",
                    RegionNameEnglish = "Georgia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "HI",
                    RegionNameEnglish = "Hawaii"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IA",
                    RegionNameEnglish = "Iowa"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ID",
                    RegionNameEnglish = "Idaho"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IL",
                    RegionNameEnglish = "Illinois"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IN",
                    RegionNameEnglish = "Indiana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "KS",
                    RegionNameEnglish = "Kansas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "KY",
                    RegionNameEnglish = "Kentucky"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "LA",
                    RegionNameEnglish = "Louisiana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MD",
                    RegionNameEnglish = "Maryland"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ME",
                    RegionNameEnglish = "Maine"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MA",
                    RegionNameEnglish = "Massachsetts"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MI",
                    RegionNameEnglish = "Michigan"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MN",
                    RegionNameEnglish = "Minnesota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MS",
                    RegionNameEnglish = "Mississippi"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MO",
                    RegionNameEnglish = "Missouri"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MT",
                    RegionNameEnglish = "Montana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NE",
                    RegionNameEnglish = "Nebraska"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NV",
                    RegionNameEnglish = "Nevada"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NH",
                    RegionNameEnglish = "New Hampshire"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NJ",
                    RegionNameEnglish = "New Jersey"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NM",
                    RegionNameEnglish = "New Mexico"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NY",
                    RegionNameEnglish = "New York"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NC",
                    RegionNameEnglish = "North Carolina"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ND",
                    RegionNameEnglish = "North Dakota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OH",
                    RegionNameEnglish = "Ohio"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OK",
                    RegionNameEnglish = "Oklahoma"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OR",
                    RegionNameEnglish = "Oregon"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "PA",
                    RegionNameEnglish = "Pennsylvania"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "RI",
                    RegionNameEnglish = "Rhode Island"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "SC",
                    RegionNameEnglish = "South Carolina"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "SD",
                    RegionNameEnglish = "South Dakota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "TN",
                    RegionNameEnglish = "Tennessee"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "TX",
                    RegionNameEnglish = "Texas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "UT",
                    RegionNameEnglish = "Utah"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VT",
                    RegionNameEnglish = "Vermont"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VA",
                    RegionNameEnglish = "Virginia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WA",
                    RegionNameEnglish = "Washington"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WV",
                    RegionNameEnglish = "West Virginia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WI",
                    RegionNameEnglish = "Wisconsin"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WY",
                    RegionNameEnglish = "Wyoming"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AS",
                    RegionNameEnglish = "American Samoa"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "FM",
                    RegionNameEnglish = "Federated States of Micronesia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "GU",
                    RegionNameEnglish = "Guam"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MH",
                    RegionNameEnglish = "Marshall Islands"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MP",
                    RegionNameEnglish = "Northern Mariana Islands"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "PR",
                    RegionNameEnglish = "Puerto Rico"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VI",
                    RegionNameEnglish = "US Virgin Islands"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "AB",
                    RegionNameEnglish = "Alberta"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "BC",
                    RegionNameEnglish = "British Columbia"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "MB",
                    RegionNameEnglish = "Manitoba"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NB",
                    RegionNameEnglish = "New Brunswick"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NF",
                    RegionNameEnglish = "Newfoundland"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NT",
                    RegionNameEnglish = "Northwest Territories"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NS",
                    RegionNameEnglish = "Nova Scotia"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NU",
                    RegionNameEnglish = "Nunavut"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "ON",
                    RegionNameEnglish = "Ontario"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "PE",
                    RegionNameEnglish = "Prince Edward Island"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "QC",
                    RegionNameEnglish = "Québec"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "SK",
                    RegionNameEnglish = "Saskatchewan"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "YT",
                    RegionNameEnglish = "Yukon"
                }
            };
      foreach (var r in regions)
      {
        context.Regions.Add(r);
      }
      context.SaveChanges();
    }

    private static void PrintRegions()
    {
      using (var ctx = new MusicTimeContext())
      {
        var list = ctx.Regions.ToList();
        var bands = ctx.Bands.ToList();
        foreach (var r in list)
        {
          Console.WriteLine($"{r.RegionNameEnglish}, {r.Iso3}");
        }
      }
    }

    private static void PrintCustomerPostalAddresses()
    {
      var repo = new CustomerRepository(new MusicTimeContext());
      var customer = repo.Find(6);
      var cevm = repo.GetCustomer(6);
      foreach (var address in cevm.PostalAddresses)
      {
        Console.WriteLine($"{address.Id}, {address.PostalCode}");
      }
      //using (var context = new MusicTimeContext())
      //{
      //  context.PostalAddresses.Add(new PostalAddress
      //  {
      //    CustomerID = 6,
      //    Id = 4,
      //    StreetAddress1 = "9310 la colonia",
      //    City = "Fountain Valley",
      //    IsDefault = false
      //  });
      //  context.SaveChanges();
      //}
    }

    private static void GetCustomersWithRelated()
    {
      var repo = new CustomerRepository(new MusicTimeContext());
      var customers = repo.GetCustomers();
      foreach (var customer in customers)
      {
        Console.WriteLine($"{customer.CountryName}");
      }
    }

    private static void InsertAlbum()
    {
      using (var context = new MusicTimeContext())
      {
        context.Albums.Add(new Album
        {
          Title = "Through the fire and the flames",
          Genre = GenreEnum.Metal,
          Price = 12.50M,
          BandId = 1
        });
        context.Albums.Add(new Album
        {
          Title = "Song about Jane",
          Genre = GenreEnum.Rock,
          Price = 10.50M,
          BandId = 2
        });
        context.SaveChanges();
      }
    }

    private static void InsertArtist()
    {
      var artists = new List<Artist>()
      {
        new Artist { Id = 1, FirstName = "Herman", LastName = "Li", Age = 45, ArtistBio = "Herman Li is a Hong Kong-born British musician who is one of two lead guitarists for the power metal band DragonForce.", BandId = 1, Instrument = Instrument.Guitar },
        new Artist { Id = 2, FirstName = "ZP", LastName = "Theart", Age = 46, ArtistBio = "ZP De Villiers Theart is a South African singer, songwriter, and the lead vocalist for the American glam metal band Skid Row.", Instrument = Instrument.Vocals, BandId = 1 },
        new Artist { Id = 3, FirstName = "Dave", LastName = "Mackintosh", Age = 45, ArtistBio = "Dave Mackintosh is a Scottish drummer, best known as the former drummer for the power metal band DragonForce.", Instrument = Instrument.Drums, BandId = 1 },
        new Artist { Id = 5, FirstName = "Steve", LastName = "Williams", Age = 50, ArtistBio = "Steve Williams is a Welsh musician, keyboardist and main songwriter for British power metal band Power Quest and former member of DragonForce.", Instrument = Instrument.Keys, BandId = 1 },
        new Artist { Id = 6, FirstName = "Adam", LastName = "Levine", Age = 42, ArtistBio = "Adam Noah Levine is an American singer, musician, and the lead vocalist of the pop rock band Maroon 5. Levine began his musical career in 1994 with the band Kara's Flowers, of which he was the lead vocalist and guitarist.", Instrument = Instrument.Vocals, BandId = 2 },
        new Artist { Id = 7, FirstName = "James", LastName = "Valentine", Age = 43, ArtistBio = "s an American musician and songwriter. He is the lead guitarist and backing vocalist for the pop rock band Maroon 5. ", Instrument = Instrument.Guitar, BandId = 2 },
        new Artist { Id = 8, FirstName = "Matt", LastName = "Flynn", Age = 51, Instrument = Instrument.Drums, ArtistBio = "Matthew Flynn is an American musician and record producer. He is the drummer for the pop rock band Maroon 5", BandId = 2 },
        new Artist { Id = 9, FirstName = "Michael", LastName = "Madden", Age = 42, Instrument = Instrument.Guitar, ArtistBio = "Madden was born in Austin, Texas. He began playing in junior high school at the Brentwood School in Los Angeles, playing in garages along with friends Jesse Carmichael (guitar/vocals) and Adam Levine (vocals/guitar).", BandId = 2 },
        new Artist { Id = 10, FirstName = "Sam", LastName = "Farrar", Age = 43, Instrument = Instrument.Bass, ArtistBio = "He is best known as a member of the pop rock band Maroon 5, in which he plays several instruments. A frequent collaborator with the band since the 1990s, he joined as a touring member in 2012 and was promoted to an official member in 2016.", BandId = 2 }
      };

      using (var context = new MusicTimeContext())
      {
        foreach (var artist in artists)
        {
          context.Artists.Add(artist);
        }
        context.SaveChanges();
      }
    }

    private static void InsertBands()
    {
      var bands = new List<Band>()
      {
        new Band { id = 1, Name = "DragonForce", BandBio ="DragonForce are a British power metal band from London, England. ",Genre = GenreEnum.Metal },
        new Band { id = 2, Name = "Maroon 5", BandBio = "Maroon 5 is an American pop rock band from Los Angeles", Genre = GenreEnum.Pop}
      };

      using (var context = new MusicTimeContext())
      {
        foreach (var band in bands)
        {
          context.Bands.Add(band);

        }
        context.SaveChanges();
      }
    }
  }
}
