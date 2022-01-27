using MusicTime.Domain;
using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class MusicTimeDatabaseSeeder : DropCreateDatabaseIfModelChanges<MusicTimeContext>
  {
    protected override void Seed(MusicTimeContext context)
    {

    }

  }
}
