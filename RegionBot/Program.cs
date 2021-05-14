using IdentityModel.Client;
using Newtonsoft.Json;
using RegionBot.Const;
using RegionBot.Services;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RegionBot
{
    class Program
    {
        static void Main(string[] args)
        {


            //try
            //{
            //    CityManager cityManager = new CityManager();
            //    cityManager.Add();
            //}
            //catch (System.Exception ex)
            //{

            //    Console.WriteLine(ex.GetBaseException().Message);
            //}
            //Console.WriteLine("İller bitti");
            //Console.ReadKey();



            //try
            //{
            //    DistrictManager districtManager = new DistrictManager();
            //    districtManager.Add();
            //}
            //catch (System.Exception ex)
            //{

            //    Console.WriteLine(ex.GetBaseException().Message);
            //}
            //Console.WriteLine("İlçeler bitti");
            //Console.ReadKey();





            //try
            //{
            //    TownManager townManager = new TownManager();
            //    townManager.Add();
            //}
            //catch (System.Exception ex)
            //{

            //    Console.WriteLine(ex.GetBaseException().Message);
            //}
            //Console.WriteLine("Bucaklar bitti");
            //Console.ReadKey();



            //try
            //{
            //    VillageManager villageManager = new VillageManager();
            //    villageManager.Add();
            //}
            //catch (System.Exception ex)
            //{

            //    Console.WriteLine(ex.GetBaseException().Message);
            //}
            //Console.WriteLine("Köyler bitti");
            //Console.ReadKey();


            //try
            //{
            //    NeighborhoodManager neighborhoodManager = new NeighborhoodManager();
            //    neighborhoodManager.Add();
            //}
            //catch (System.Exception ex)
            //{

            //    Console.WriteLine(ex.GetBaseException().Message);
            //}
            //Console.WriteLine("Mahalleler bitti");
            //Console.ReadKey();

            try
            {
                StreetManager streetManager = new StreetManager();
                streetManager.Add();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.GetBaseException().Message);
            }
            Console.WriteLine("Caddeler bitti");
            Console.WriteLine("TURKNET ADDRESS SERVİS AZAT OLDU , İYİ SÖMÜRDÜK YALNIZ VERİLERİ :D");
            Console.ReadKey();






        }
    }
}
