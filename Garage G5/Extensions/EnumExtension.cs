using Garage_G5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_G5.Extensions
{
    public static class EnumExtensions
    {
        //    public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue)
        //    {
        //        return from Enum e in Enum.GetValues(enumValue.GetType())
        //               select new SelectListItem
        //               {
        //                   Selected = e.Equals(enumValue),
        //                   Text = e.ToDescription(),
        //                   Value = e.ToString()
        //               };
        //    }

        //    public static string ToDescription(this Enum value)
        //    {
        //        var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        //        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        //    }
      public  static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue, int freePlaces,int id,VehicleType vehicletype=0)
        {
            //boocle on enum
            List<SelectListItem> vehicleTypes = new List<SelectListItem>();
            if (id == 0)
            {
                foreach (var type in Enum.GetNames(typeof(VehicleType)))
                {

                    int value = (int)Enum.Parse(typeof(VehicleType), type);
                    vehicleTypes.Add(new SelectListItem
                    {
                        Text = type.ToString(),
                        Value = value.ToString(),
                        Disabled = CheckFreePlaces(value, freePlaces),
                    });
                }
            }
            else
            {
                //On Edit
                foreach (var type in Enum.GetNames(typeof(VehicleType)))
                {

                    int value = (int)Enum.Parse(typeof(VehicleType), type);
                    vehicleTypes.Add(new SelectListItem
                    {
                        Text = type.ToString(),
                        Value = value.ToString(),
                       Disabled = CheckOnSameVehicleType(value,freePlaces,vehicletype),

                    });
                }

            }
            return vehicleTypes;

        }

        private static bool CheckOnSameVehicleType(int val,int freePlaces,VehicleType vehicleType)
        {
            switch (val)
            {
                case (int)VehicleType.Sedan:
                case (int)VehicleType.Coupe:
                case (int)VehicleType.Roaster:
                case (int)VehicleType.MiniVan:
                case (int)VehicleType.Van:               
                        return false;
                case (int)VehicleType.Truck:
                case (int)VehicleType.BigTruck:
                    if (freePlaces >= 1 || vehicleType == VehicleType.BigTruck||vehicleType ==VehicleType.Truck)
                    {
                        return false;

                    }
                    else return true;
                case (int)VehicleType.Boat:
                case (int)VehicleType.Airplane:
                    if (vehicleType == VehicleType.Boat || vehicleType == VehicleType.Airplane||(freePlaces==1 && (vehicleType==VehicleType.BigTruck)||vehicleType==VehicleType.Truck )||freePlaces>=2)
                    {
                        return false;

                    }
                    else return true;
                default:
                    return false;
            }

        }

        static bool CheckFreePlaces(int val ,int freePlaces)
        {
            switch (val)
            {
                case (int)VehicleType.Sedan:
                case (int)VehicleType.Coupe:
                case (int)VehicleType.Roaster:
                case (int)VehicleType.MiniVan:
                case (int)VehicleType.Van:
                    if (freePlaces >= 1)
                    {
                        return false;

                    }
                    else return true;
                case (int)VehicleType.Truck:
                case (int)VehicleType.BigTruck:
                    if (freePlaces >= 2)
                    {
                        return false;

                    }
                    else return true;
                case (int)VehicleType.Boat:
                case (int)VehicleType.Airplane:
                    if (freePlaces >= 3)
                    {
                        return false;

                    }
                    else return true;
                default:
                    return false;
            }

        }




    }
}
