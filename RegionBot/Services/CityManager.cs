
using RegionBot.Const;
using RegionBot.Context;
using RegionBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RegionBot
{
    public class CityManager
    {
        public void Add()
        {

            EntityContext context = new EntityContext();
            //1.Seviye : İller Ekleme
            RequestService service = new RequestService();
            Console.WriteLine(" TÜRKİYENİN İLLERİ");
            List<Region> cities = service.GetRegions(RegionConst.GetBBKCityList, RegionConst.Kod, RegionConst.lstIl);
            Console.WriteLine("-----------------------------------------1.SEVİYE BAŞLADI----------------------------------------");
            foreach (Region city in cities)
            {

                Console.WriteLine(" ");
                Console.WriteLine("    " + city.Name + "  ( ID : " + city.ID + ")");

                Region region = new Region();
                region.Alias = "il";
                region.Name = city.Name;
                //Service - istek için ID
                region.ServiceilID = city.ID;
                context.Regions.Add(region);
                context.SaveChanges();

            }
            Console.WriteLine("--------------------------------------------------1.SEVİYE BİTTİ ---------------------------------------------");


        }
    }
}
