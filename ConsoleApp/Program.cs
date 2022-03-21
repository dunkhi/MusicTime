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
      //GetCustomersWithRelated();
      PrintCustomerPostalAddresses();
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

    private static void RetrieveDataWithStoredProecedure()
    {
      throw new NotImplementedException();
    }

    private static void InsertBands()
    {
      var bands = new List<Band>()
      {
        new Band { id = 13, Name = "DragonForce", BandBio ="DragonForce are a British power metal band from London, England. The band was formed in 1999 by guitarists Herman Li and Sam Totman, and are known for their long and fast guitar solos, fantasy-themed lyrics and retro video game-influenced sound.",Genre = GenreEnum.Metal },
        new Band { id = 18, Name = "Maroon 5", BandBio = "Maroon 5 is an American pop rock band from Los Angeles, California. It currently consists of lead vocalist Adam Levine, keyboardist and rhythm guitarist Jesse Carmichael, lead guitarist James Valentine, drummer Matt Flynn, keyboardist PJ Morton and multi-instrumentalist and occasional bassist Sam Farrar.", Genre = GenreEnum.Pop}
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
