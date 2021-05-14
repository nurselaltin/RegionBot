using RegionBot.Const;
using RegionBot.Context;
using RegionBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegionBot.Services
{
    public class DistrictManager
    {


        public void Add()
        {

            EntityContext context = new EntityContext();
            RequestService service = new RequestService();
            List<Region> cities = context.Regions.Where(x => x.Alias == "il").ToList();

            foreach (var city in cities)
            {
                List<Region> districts = service.GetRegions(RegionConst.GetBBKCountyList, RegionConst.IlKod + "" + city.ServiceilID, RegionConst.lstIlce);

                Console.WriteLine(" ");
                Console.WriteLine("    " + city.Name + "  iLİNİN İLÇELERİ");
                Console.WriteLine("-----------------------------------------2.SEVİYE BAŞLADI----------------------------------------");
                foreach (Region district in districts)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("    " + district.Name + "  ( ID : " + district.ID + ")");
                    Region region = new Region();
                    region.Alias = "ilce";
                    region.Name = district.Name;
                    //DB sorgulamak için ID
                    region.ilID = city.ID;
                    //SERVİCE - istek için 
                    region.ServiceilID = city.ServiceilID;
                    region.ServiceilceID = district.ID;
                    context.Regions.Add(region);
                    context.SaveChanges();
                }
                Console.WriteLine("--------------------------------------------------2.SEVİYE BİTTİ ---------------------------------------------");

            }




        }



    }
}
