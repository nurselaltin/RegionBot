
using RegionBot.Const;
using RegionBot.Context;
using RegionBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RegionBot
{
    public class RegionManager
    {
        public void Add()
        {

            EntityContext context = new EntityContext();
            //1.Seviye : İller Ekleme
            RequestService service = new RequestService();
            List<Region> cities = service.GetRegions(RegionConst.GetBBKCityList, RegionConst.Kod, RegionConst.lstIl);
            Console.WriteLine("-----------------------------------------1.SEVİYE BAŞLADI----------------------------------------");
            foreach (Region city in cities)
            {

                Console.WriteLine(" ");
                Console.WriteLine("    " + city.Name + "  ( ID : " + city.ID + ")");

                Region region = new Region();
                region.Alias = "il";
                region.Name = city.Name;
                context.Regions.Add(region);
                context.SaveChanges();



                List<Region> districts = service.GetRegions(RegionConst.GetBBKCountyList, RegionConst.IlKod + "" + city.ID, RegionConst.lstIlce);
                Console.WriteLine("-----------------------------------------2.SEVİYE BAŞLADI----------------------------------------");
                foreach (Region district in districts)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("    " + district.Name + "  ( ID : " + district.ID + ")");

                    Region region2 = new Region();
                    region2.Alias = "ilçe";
                    region2.Name = district.Name;
                    region2.ilID = region.ID;
                    context.Regions.Add(region2);
                    context.SaveChanges();

                    Thread.Sleep(2000);
                    List<Region> townShips = service.GetRegions(RegionConst.GetBBKBucakList, RegionConst.IlceKod + "" + district.ID, RegionConst.lstBucak);


                    Console.WriteLine("-----------------------------------------3.SEVİYE BAŞLADI----------------------------------------");
                    foreach (Region townShip in townShips)
                    {


                        Console.WriteLine(" ");
                        Console.WriteLine("BUCAK ");
                        Console.WriteLine("    " + townShip.Name + "  ( ID : " + townShip.ID + ")");

                        Region region3 = new Region();
                        region3.Alias = "bucak";
                        region3.Name = townShip.Name;
                        region3.ilID = region.ID;
                        region3.ilceID = region2.ID;
                        context.Regions.Add(region3);
                        context.SaveChanges();

                        Thread.Sleep(2000);
                        //4.Seviye : Bucağa Ait Olan  Köyleri Ekle
                        List<Region> villages = service.GetRegions(RegionConst.GetBBKKoyList, RegionConst.BucakKod + "" + townShip.ID, RegionConst.lstKoy);
                        Console.WriteLine("-----------------------------------------4.SEVİYE BAŞLADI----------------------------------------");
                        foreach (Region village in villages)
                        {

                            Console.WriteLine(" ");
                            Console.WriteLine("KÖY ");
                            Console.WriteLine("    " + village.Name + "  ( ID : " + village.ID + ")");
                            //DB ye kayıt
                            Region region4 = new Region();
                            region4.Alias = "koy";
                            region4.Name = village.Name;
                            region4.ilID = region.ID;
                            region4.ilceID = region2.ID;
                            region4.bucakID = region3.ID;
                            context.Regions.Add(region4);
                            context.SaveChanges();

                            //5.Seviye : Köye  Ait Olan Mahalleri Ekle  
                            Thread.Sleep(2000);
                            List<Region> neighborhoods = service.GetRegions(RegionConst.GetBBKMahalleList, RegionConst.KoyKod + "" + village.ID, RegionConst.lstMahalle);
                            Console.WriteLine("-----------------------------------------5.SEVİYE BAŞLADI----------------------------------------");
                            foreach (Region neighborhood in neighborhoods)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("MAHALLE ");
                                Console.WriteLine("    " + neighborhood.Name + "  ( ID : " + neighborhood.ID + ")");
                                //DB ye kayıt
                                Region region5 = new Region();
                                region5.Alias = "mahalle";
                                region5.Name = neighborhood.Name;
                                region5.ilID = region.ID;
                                region5.ilceID = region2.ID;
                                region5.bucakID = region3.ID;
                                region5.koyID = region4.ID;
                                context.Regions.Add(region5);
                                context.SaveChanges();

                                Thread.Sleep(2000);
                                //6.Seviye : Mahalleye Ait Olan  Caddeleri Ekle 
                              
                                List<Region> streets = service.GetRegions(RegionConst.GetBBKCaddeList, RegionConst.MahalleKod + "" + neighborhood.ID, RegionConst.lstCadde);

                                Console.WriteLine("-----------------------------------------6.SEVİYE BAŞLADI----------------------------------------");
                                foreach (Region street in streets)
                                {
                                    Console.WriteLine(" ");
                                    Console.WriteLine("CADDE ");
                                    Console.WriteLine("    " + street.Name + "  ( ID : " + street.ID + ")");
                                    //DB ye kayıt
                                    Region region6 = new Region();
                                    region6.Alias = "cadde - sokak";
                                    region6.Name = street.Name;
                                    region6.ilID = region.ID;
                                    region6.ilceID = region2.ID;
                                    region6.bucakID = region3.ID;
                                    region6.koyID = region4.ID;
                                    region6.mahalleID = region5.ID;
                                    context.Regions.Add(region6);
                                    context.SaveChanges();

                                }
                                Console.WriteLine("-----------------------------------------6.SEVİYE BİTTİ----------------------------------------");
                           

                            }
                            Console.WriteLine("-----------------------------------------5.SEVİYE BİTTİ----------------------------------------");

                            
                        }
                        Console.WriteLine("--------------------------------------------------4.SEVİYE BİTTİ ---------------------------------------------");

                        Thread.Sleep(2000);
                    }
                    Console.WriteLine("--------------------------------------------------3.SEVİYE BİTTİ ---------------------------------------------");
                   
                    Thread.Sleep(10000);
                     

                }

                Console.WriteLine("--------------------------------------------------2.SEVİYE BİTTİ ---------------------------------------------");


            }
            Console.WriteLine("--------------------------------------------------1.SEVİYE BİTTİ ---------------------------------------------");


        }
    }
}
