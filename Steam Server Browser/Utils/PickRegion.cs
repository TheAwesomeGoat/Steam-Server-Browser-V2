using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Steam_Server_Browser.SteamClient.Builder;

namespace Steam_Server_Browser.Utils
{
    public class PickRegion
    {
        public PacketBuilder.EnumRegions Pick(string type)
        {
            switch (type)
            {
                case "Africa":
                    return PacketBuilder.EnumRegions.Africa;
                case "Asia":
                    return PacketBuilder.EnumRegions.Asia;
                case "Australia":
                    return PacketBuilder.EnumRegions.Australia;
                case "Europe":
                    return PacketBuilder.EnumRegions.Europe;
                case "MiddleEast":
                    return PacketBuilder.EnumRegions.MiddleEast;
                case "SouthAmerica":
                    return PacketBuilder.EnumRegions.SouthAmerica;
                case "UsEastCoast":
                    return PacketBuilder.EnumRegions.UsEastCoast;
                case "UsWestCoast":
                    return PacketBuilder.EnumRegions.UsWestCoast;
                default:
                    return PacketBuilder.EnumRegions.All;
            }
        }
    }
}
