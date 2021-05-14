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
    public class StreetManager
    {
        public void Add()
        {

            EntityContext context = new EntityContext();
            RequestService service = new RequestService();
            //List<Region> cities = context.Regions.Where(x => x.Alias == "il").ToList();
           // List<Region> cities = context.Regions.Where(x => x.Alias == "il").Where(s => s.ID > 37 ).Where( z => z.ID < 40).ToList();
            List<Region> cities = context.Regions.Where(x => x.Alias == "il").Where(s => s.ID == 41).ToList();

            foreach (var city in cities)
            {
                //List<Region> districts = context.Regions.Where(x => x.Alias == "ilce").Where(s => s.ilID == city.ID).ToList();
          
                List<Region> districts = context.Regions.Where(x => x.Alias == "ilce").Where(s => s.ilID == city.ID).Where(z => z.ID > 590 ).ToList();
                Console.WriteLine(" ");
                Console.WriteLine("    " + city.Name + "  iLİNİN İLÇELERİ");
                Console.WriteLine("-----------------------------------------2.SEVİYE BAŞLADI----------------------------------------");
                foreach (Region district in districts)
                {
                    List<Region> townShips = context.Regions.Where(x => x.Alias == "bucak").Where(s => s.ilID == city.ID).Where(z => z.ilceID == district.ID).ToList();
                    Console.WriteLine(" ");
                    Console.WriteLine("    " + district.Name + "  İLÇESİNİN BUCAKLARI");
                    Console.WriteLine("-----------------------------------------3.SEVİYE BAŞLADI----------------------------------------");
                    foreach (Region townShip in townShips)
                    {


                        //4.Seviye : Bucağa Ait Olan  Köyleri Ekle
                        List<Region> villages = context.Regions.Where(x => x.Alias == "koy").Where(s => s.ilID == city.ID).Where(z => z.ilceID == district.ID).Where(t => t.bucakID == townShip.ID).ToList();
                        Console.WriteLine("-----------------------------------------4.SEVİYE BAŞLADI----------------------------------------");
                        foreach (Region village in villages)
                        {

                            Console.WriteLine(" ");
                            Console.WriteLine("    " + village.Name + "  KÖYÜNÜN MAHALLELERİ");
                            //5.Seviye : Köye  Ait Olan Mahalleri Ekle  
                            Thread.Sleep(2000);
                            List<Region> neighborhoods = context.Regions.Where(x => x.Alias == "mahalle").Where(s => s.ilID == city.ID).Where(z => z.ilceID == district.ID).Where(t => t.bucakID == townShip.ID).Where(v => v.koyID == village.ID).ToList();
                            Console.WriteLine("-----------------------------------------5.SEVİYE BAŞLADI----------------------------------------");
                            foreach (Region neighborhood in neighborhoods)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("MAHALLE ");
                                Console.WriteLine("    " + neighborhood.Name + "  MAHALLENİN CADDELERİ");
                                //6.Seviye : Mahalleye Ait Olan  Caddeleri Ekle 
                                //Servisten gelen Mahalle ID = 0  ve O'dan küçük ID 'ler var . Bunlara ait serviste veri yok . Bunu önlenmek adına if() sokuyoruz.
                                if (neighborhood.ServicemahalleID != 0 && neighborhood.ServicemahalleID > 0)
                                {
                                    List<Region> streets = service.GetRegions(RegionConst.GetBBKCaddeList, RegionConst.MahalleKod + "" + neighborhood.ServicemahalleID, RegionConst.lstCadde);

                                    Console.WriteLine("-----------------------------------------6.SEVİYE BAŞLADI----------------------------------------");
                                    foreach (Region street in streets)
                                    {
                                        Console.WriteLine(" ");
                                        Console.WriteLine("CADDE ");
                                        Console.WriteLine("    " + street.Name + "  ( ID : " + street.ID + ")");
                                        //DB ye kayıt
                                        Region region = new Region();
                                        region.Alias = "cadde - sokak";
                                        region.Name = street.Name;
                                        region.ilID = city.ID;
                                        region.ilceID = district.ID;
                                        region.bucakID = townShip.ID;
                                        region.koyID = village.ID;
                                        region.mahalleID = neighborhood.ID;

                                        region.ServiceilID = city.ServiceilID;
                                        region.ServiceilceID = district.ServiceilceID;
                                        region.ServicebucakID = townShip.ServicebucakID;
                                        region.ServicekoyID = village.ServicekoyID;
                                        region.ServicemahalleID = neighborhood.ServicemahalleID;


                                        context.Regions.Add(region);
                                        context.SaveChanges();

                                    }
                                    Console.WriteLine("-----------------------------------------6.SEVİYE BİTTİ----------------------------------------");

                                    Thread.Sleep(2000);

                                }

                            }
                            Console.WriteLine("-----------------------------------------5.SEVİYE BİTTİ----------------------------------------");


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
