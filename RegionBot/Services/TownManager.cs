using RegionBot.Const;
using RegionBot.Context;
using RegionBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RegionBot.Services
{
    public class TownManager
    {



        public void Add()
        {

            EntityContext context = new EntityContext();
            RequestService service = new RequestService();
            List<Region> cities = context.Regions.Where(x => x.Alias == "il").ToList();

            foreach (var city in cities)
            {
                List<Region> districts = context.Regions.Where(x => x.Alias == "ilce").Where(s =>s.ilID == city.ID).ToList();
                Console.WriteLine(" ");
                Console.WriteLine("    " + city.Name + "  iLİNİN İLÇELERİ");
                Console.WriteLine("-----------------------------------------2.SEVİYE BAŞLADI----------------------------------------");
                foreach (Region district in districts)
                {
            
                    List<Region> townShips = service.GetRegions(RegionConst.GetBBKBucakList, RegionConst.IlceKod + "" + district.ServiceilceID, RegionConst.lstBucak);
                    Console.WriteLine(" ");
                    Console.WriteLine("    " + district.Name + "  İLÇESİNİN BUCAKLARI");
                    Console.WriteLine("-----------------------------------------3.SEVİYE BAŞLADI----------------------------------------");
                    foreach (Region townShip in townShips)
                    {


                        Console.WriteLine(" ");
                        Console.WriteLine("BUCAK ");
                        Console.WriteLine("    " + townShip.Name + "  ( ID : " + townShip.ID + ")");

                        Region region = new Region();
                        region.Alias = "bucak";
                        region.Name = townShip.Name;
                        //DB için ID 
                        region.ilID = city.ID;
                        region.ilceID = district.ID;
                        //Service-istek için ID
                        region.ServiceilID = city.ServiceilID;
                        region.ServiceilceID = district.ServiceilceID;
                        region.ServicebucakID = townShip.ID;
                        context.Regions.Add(region);
                        context.SaveChanges();
                    }
                    Console.WriteLine("--------------------------------------------------3.SEVİYE BİTTİ ---------------------------------------------");

                    Thread.Sleep(1000);
                }
                Console.WriteLine("--------------------------------------------------2.SEVİYE BİTTİ ---------------------------------------------");

            }




        }




    }
}
