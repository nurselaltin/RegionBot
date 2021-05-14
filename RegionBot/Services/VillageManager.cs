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
    public class VillageManager
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

                    List<Region> townShips = context.Regions.Where(x => x.Alias == "bucak").Where(s => s.ilID == city.ID).Where( z => z.ilceID == district.ID).ToList();
                    Console.WriteLine(" ");
                    Console.WriteLine("    " + district.Name + "  İLÇESİNİN BUCAKLARI");
                    Console.WriteLine("-----------------------------------------3.SEVİYE BAŞLADI----------------------------------------");
                    foreach (Region townShip in townShips)
                    {


                        //4.Seviye : Bucağa Ait Olan  Köyleri Ekle
                        List<Region> villages = service.GetRegions(RegionConst.GetBBKKoyList, RegionConst.BucakKod + "" + townShip.ServicebucakID, RegionConst.lstKoy);
                        Console.WriteLine("-----------------------------------------4.SEVİYE BAŞLADI----------------------------------------");
                        foreach (Region village in villages)
                        {

                            Console.WriteLine(" ");
                            Console.WriteLine("KÖY ");
                            Console.WriteLine("    " + village.Name + "  ( ID : " + village.ID + ")");
                            //DB ye kayıt
                            Region region = new Region();
                            region.Alias = "koy";
                            region.Name = village.Name;
                            //DB için ID 
                            region.ilID = city.ID;
                            region.ilceID = district.ID;
                            region.bucakID = townShip.ID;

                            //Service-istek için ID
                            region.ServiceilID = city.ServiceilID;
                            region.ServiceilceID = district.ServiceilceID;
                            region.ServicebucakID = townShip.ServicebucakID;
                            region.ServicekoyID = village.ID;
                            context.Regions.Add(region);
                            context.SaveChanges();                    

                        }

                    }
                    Console.WriteLine("--------------------------------------------------3.SEVİYE BİTTİ ---------------------------------------------");

                    Thread.Sleep(1000);
                }
                Console.WriteLine("--------------------------------------------------2.SEVİYE BİTTİ ---------------------------------------------");

            }




        }




    }
}
