using System;
using System.Data.SqlTypes;
using  System.Collections;
using AltSource_TestingProject.Model;

namespace AltSource_TestingProject.Service
{
    public  interface IVendorAction
    {
        int SellClothes(Guid Id, int quanlity,string typeClothes);
        int BuyClothes(Clothes clothes);
        
 
    }
}