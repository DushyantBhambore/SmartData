using MagicVilla.Model;
using MagicVilla.Model.Dto;

namespace MagicVilla.Data
{
    public static class VillaStore
    {
        public static List<Villadto> villalist = new List<Villadto>
        {
                new Villadto {Id=1,Names="Pool Villas",sqft=300,Occupancy=4},  
                new Villadto {Id=2,Names="gardern Villas",sqft=400,Occupancy=6}

        };

        public static List<Villas> villas = new List<Villas>
        {
          new Villas {Id=1,Names="Pool Villas" },
                new Villas {Id=2,Names="gardern Villas"}

        };
    }
}
