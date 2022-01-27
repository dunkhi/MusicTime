namespace MusicTime.Data.Migrations
{
  using MusicTime.Domain;
  using MusicTime.Domain.Enums;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<MusicTime.Data.MusicTimeContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(MusicTime.Data.MusicTimeContext context)
    {
      var countries = new List<Country>
      {
        new Country {
                    Iso3 = "USA",
                    CountryNameEnglish = "United States of America"
                },
                new Country
                {
                    Iso3 = "CAN",
                    CountryNameEnglish = "Canada"
                },
                new Country
                {
                    Iso3 = "FRA",
                    CountryNameEnglish = "France"
                }
      };
      countries.ForEach(c => context.Countries.AddOrUpdate(p => p.Iso3, c));
      context.SaveChanges();

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
      regions.ForEach(r => context.Regions.AddOrUpdate(p => p.RegionCode, r));
      context.SaveChanges();

      var bands = new List<Band>
      {
        new Band
        {
          id = 1,
        Name = "DragonForce",
        BandBio = "DragonForce are a British power metal band from London, England. The band was formed in 1999 by guitarists Herman Li and Sam Totman, and are known for their long and fast guitar solos, fantasy-themed lyrics and retro video game-influenced sound.",
        Genre = GenreEnum.Metal
        },
        new Band
        {
         id = 2,
        Name = "Maroon 5",
        BandBio = "Maroon 5 is an American pop rock band from Los Angeles, California. It currently consists of lead vocalist Adam Levine, keyboardist and rhythm guitarist Jesse Carmichael, lead guitarist James Valentine, drummer Matt Flynn, keyboardist PJ Morton and multi-instrumentalist and occasional bassist Sam Farrar.",
        Genre = GenreEnum.Pop
        }
      };
      bands.ForEach(b => context.Bands.AddOrUpdate(p => p.id));
      context.SaveChanges();

      
      var artists = new List<Artist>
      {
        new Artist
        {
          Id = 1,
        FirstName = "Herman",
        LastName = "Li",
        Age = 45,
        ArtistBio = "Herman Li is a Hong Kong-born British musician who is one of two lead guitarists for the power metal band DragonForce.",
        BandId = 1
        },
        new Artist
        {
          Id = 2,
        FirstName = "ZP",
        LastName = "Theart",
        Age = 46,
        ArtistBio = "ZP De Villiers Theart is a South African singer, songwriter, and the lead vocalist for the American glam metal band Skid Row.",
        Instrument = Instrument.Vocals,
        BandId = 1
        },
        new Artist
        {
          Id = 3,
        FirstName = "Dave",
        LastName = "Mackintosh",
        Age = 45,
        ArtistBio = "Dave Mackintosh is a Scottish drummer, best known as the former drummer for the power metal band DragonForce.",
        Instrument = Instrument.Drums,
        BandId = 1
        },
        new Artist
        {
          Id = 4,
        FirstName = "Steve",
        LastName = "Williams",
        Age = 50,
        ArtistBio = "Steve Williams is a Welsh musician, keyboardist and main songwriter for British power metal band Power Quest and former member of DragonForce.",
        Instrument = Instrument.Keys,
        BandId = 1
        },
        new Artist
        {
          Id = 5,
          FirstName = "Adam",
        LastName = "Levine",
        Age = 42,
        ArtistBio = "Adam Noah Levine is an American singer, musician, and the lead vocalist of the pop rock band Maroon 5. Levine began his musical career in 1994 with the band Kara's Flowers, of which he was the lead vocalist and guitarist.",
        Instrument = Instrument.Vocals,
        BandId = 2
        },
        new Artist
        {
          Id = 6,
          FirstName = "James",
        LastName = "Valentine",
        Age = 43,
        ArtistBio = "s an American musician and songwriter. He is the lead guitarist and backing vocalist for the pop rock band Maroon 5. ",
        Instrument = Instrument.Guitar,
        BandId = 2
        },
        new Artist
        {
          Id = 7,
          FirstName = "Matt",
        LastName = "Flynn",
        Age = 51,
        Instrument = Instrument.Drums,
        ArtistBio = "Matthew Flynn is an American musician and record producer. He is the drummer for the pop rock band Maroon 5",
        BandId = 2
        },
        new Artist
        {
          Id = 8,
          FirstName = "Michael",
        LastName = "Madden",
        Age = 42,
        Instrument = Instrument.Guitar,
        ArtistBio = "Madden was born in Austin, Texas. He began playing in junior high school at the Brentwood School in Los Angeles, playing in garages along with friends Jesse Carmichael (guitar/vocals) and Adam Levine (vocals/guitar).",
        BandId = 2
        },
        new Artist
        {
          Id = 9,
          FirstName = "Sam",
        LastName = "Farrar",
        Age = 43,
        Instrument = Instrument.Bass,
        ArtistBio = "He is best known as a member of the pop rock band Maroon 5, in which he plays several instruments. A frequent collaborator with the band since the 1990s, he joined as a touring member in 2012 and was promoted to an official member in 2016.",
        BandId = 2
        },
      };
      artists.ForEach(a => context.Artists.AddOrUpdate(p => p.Id));
      context.SaveChanges();

      var venues = new List<Venue>
      {
        new Venue
        {
          Id = 1,
        Capacity = 2500,
        City = "New York",
        State = "New York",
        Name = "Madison Garden",
        Type = VenueType.Stadium
        },
        new Venue
        {
          Id = 2,
        Capacity = 9380,
        City = "Los Angeles",
        State = "California",
        Name = "Rose Bowl",
        Type = VenueType.Stadium
        },
        new Venue
        {
          Id = 3,
        Capacity = 900,
        City = "Anaheim",
        State = "California",
        Name = "Anaheim House of Blues",
        Type = VenueType.Club
        },
      };
      venues.ForEach(v => context.Venues.AddOrUpdate(p => p.Id));
      context.SaveChanges();

      var concerts = new List<Concert>()
      {
        new Concert
        {
          Id = 1,
        Name = "It's Maroony for you",
        Date = new DateTime(2022, 12, 2),
        BandId = 2,
        VenueId = 1
        },
        new Concert
        {
          Id = 2,
        Name = "Metal Time For Me",
        Date = new DateTime(2022, 4, 21),
        BandId = 1,
        VenueId = 3
        }
      };
      concerts.ForEach(c => context.Concerts.AddOrUpdate(p => p.Id));
      context.SaveChanges();

      var tickets = new List<Ticket>()
      {
        new Ticket
        {
          Id = 1,
        ConcertId = 1,
        Area = "Floor Seating",
        Price = 50.00M,
        Seat = "234A",
        PurchaseDate = new DateTime(2022, 01, 03),
        SerialNumber = "23414"
        }
      };
      tickets.ForEach(t => context.Tickets.AddOrUpdate(p => p.Id));
      context.SaveChanges();

      var customers = new List<Customer>()
      {
        new Customer
        {
          Id = 1,
        FirstName = "Greg",
        LastName = "Olsen",
        Email = "golsen@gmail.com",
        UserName = "golsen"
        }
      };
      customers.ForEach(c => context.Customers.AddOrUpdate(p => p.Id));
      context.SaveChanges();

      var customerOrders = new List<CustomerOrder>()
      {
        new CustomerOrder
        {
          Id = 1,
        CustomerId = 1,
        OrderDate = new DateTime(2022, 03, 20),
        FinalPrice = 50.00M
        }
      };
      customerOrders.ForEach(co => context.CustomerOrders.AddOrUpdate(p => p.CustomerId));
      context.SaveChanges();

      var ticketOrders = new List<TicketOrder>()
      {
        new TicketOrder
        {
          CustomerOrderId = 1,
        Id = 1,
        TicketId = 1
        }
      };
      ticketOrders.ForEach(to => context.TicketOrders.AddOrUpdate(p => p.Id));
      context.SaveChanges();
      
    }
  }
}

//context.Bands.Add(new Band
//{
//  id = 1,
//  Name = "DragonForce",
//  BandBio = "DragonForce are a British power metal band from London, England. The band was formed in 1999 by guitarists Herman Li and Sam Totman, and are known for their long and fast guitar solos, fantasy-themed lyrics and retro video game-influenced sound.",
//  Genre = GenreEnum.Metal
//});
//context.Bands.Add(new Band
//{
//  id = 2,
//  Name = "Maroon 5",
//  BandBio = "Maroon 5 is an American pop rock band from Los Angeles, California. It currently consists of lead vocalist Adam Levine, keyboardist and rhythm guitarist Jesse Carmichael, lead guitarist James Valentine, drummer Matt Flynn, keyboardist PJ Morton and multi-instrumentalist and occasional bassist Sam Farrar.",
//  Genre = GenreEnum.Pop
//});

//context.Artists.AddOrUpdate(new Artist
//{
//  Id = 1,
//  FirstName = "Herman",
//  LastName = "Li",
//  Age = 45,
//  ArtistBio = "Herman Li is a Hong Kong-born British musician who is one of two lead guitarists for the power metal band DragonForce.",
//  BandId = 1,
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  Id = 2,
//  FirstName = "ZP",
//  LastName = "Theart",
//  Age = 46,
//  ArtistBio = "ZP De Villiers Theart is a South African singer, songwriter, and the lead vocalist for the American glam metal band Skid Row.",
//  Instrument = Instrument.Vocals,
//  BandId = 1
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  Id = 3,
//  FirstName = "Dave",
//  LastName = "Mackintosh",
//  Age = 45,
//  ArtistBio = "Dave Mackintosh is a Scottish drummer, best known as the former drummer for the power metal band DragonForce.",
//  Instrument = Instrument.Drums,
//  BandId = 1
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  Id = 4,
//  FirstName = "Steve",
//  LastName = "Williams",
//  Age = 50,
//  ArtistBio = "Steve Williams is a Welsh musician, keyboardist and main songwriter for British power metal band Power Quest and former member of DragonForce.",
//  Instrument = Instrument.Keys,
//  BandId = 1
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  FirstName = "Adam",
//  LastName = "Levine",
//  Age = 42,
//  ArtistBio = "Adam Noah Levine is an American singer, musician, and the lead vocalist of the pop rock band Maroon 5. Levine began his musical career in 1994 with the band Kara's Flowers, of which he was the lead vocalist and guitarist.",
//  Instrument = Instrument.Vocals,
//  BandId = 2
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  FirstName = "James",
//  LastName = "Valentine",
//  Age = 43,
//  ArtistBio = "s an American musician and songwriter. He is the lead guitarist and backing vocalist for the pop rock band Maroon 5. ",
//  Instrument = Instrument.Guitar,
//  BandId = 2
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  FirstName = "Matt",
//  LastName = "Flynn",
//  Age = 51,
//  Instrument = Instrument.Drums,
//  ArtistBio = "Matthew Flynn is an American musician and record producer. He is the drummer for the pop rock band Maroon 5",
//  BandId = 2
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  FirstName = "Michael",
//  LastName = "Madden",
//  Age = 42,
//  Instrument = Instrument.Guitar,
//  ArtistBio = "Madden was born in Austin, Texas. He began playing in junior high school at the Brentwood School in Los Angeles, playing in garages along with friends Jesse Carmichael (guitar/vocals) and Adam Levine (vocals/guitar).",
//  BandId = 2
//});
//context.Artists.AddOrUpdate(new Artist
//{
//  FirstName = "Sam",
//  LastName = "Farrar",
//  Age = 43,
//  Instrument = Instrument.Bass,
//  ArtistBio = "He is best known as a member of the pop rock band Maroon 5, in which he plays several instruments. A frequent collaborator with the band since the 1990s, he joined as a touring member in 2012 and was promoted to an official member in 2016.",
//  BandId = 2
//});


//context.Venues.AddOrUpdate(new Venue
//{
//  Id = 1,
//  Capacity = 2500,
//  City = "New York",
//  State = "New York",
//  Name = "Madison Garden",
//  Type = VenueType.Stadium
//});
//context.Venues.AddOrUpdate(new Venue
//{
//  Id = 2,
//  Capacity = 9380,
//  City = "Los Angeles",
//  State = "California",
//  Name = "Rose Bowl",
//  Type = VenueType.Stadium
//});
//context.Venues.AddOrUpdate(new Venue
//{
//  Id = 3,
//  Capacity = 900,
//  City = "Anaheim",
//  State = "California",
//  Name = "Anaheim House of Blues",
//  Type = VenueType.Club
//});
//context.Concerts.AddOrUpdate(new Concert
//{
//  Id = 1,
//  Name = "It's Maroony for you",
//  Date = new DateTime(2022, 12, 2),
//  BandId = 2,
//  VenueId = 1
//});
//context.Concerts.AddOrUpdate(new Concert
//{
//  Id = 2,
//  Name = "Metal Time For Me",
//  Date = new DateTime(2022, 4, 21),
//  BandId = 1,
//  VenueId = 3
//});
//context.Tickets.AddOrUpdate(new Ticket
//{
//  Id = 1,
//  ConcertId = 1,
//  Area = "Floor Seating",
//  Price = 50.00M,
//  Seat = "234A",
//  PurchaseDate = new DateTime(2022, 01, 03),
//  SerialNumber = "23414"
//});
//context.Customers.AddOrUpdate(new Customer
//{
//  Id = 1,
//  FirstName = "Greg",
//  LastName = "Olsen",
//  Email = "golsen@gmail.com",
//  UserName = "golsen"
//});
//context.CustomerOrders.AddOrUpdate(new CustomerOrder
//{
//  Id = 1,
//  CustomerId = 1,
//  OrderDate = new DateTime(2022, 03, 20),
//  FinalPrice = 50.00M
//});
//context.TicketOrders.AddOrUpdate(new TicketOrder
//{
//  CustomerOrderId = 1,
//  Id = 1,
//  TicketId = 1
//});
