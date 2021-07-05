﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Steam_Server_Browser.SteamClient.Parser
{
    public class ServerIP
    {
        public List<IPEndPoint> Parse(byte[] data)
        {
            List<IPEndPoint> A = new List<IPEndPoint>();
            byte[] ByteData = data;
            ushort _port;
            for (int i = 6; i < data.Count(); i += 6)
            {
                string _ip = $"{ByteData[i]}.{ByteData[i + 1]}.{ByteData[i + 2]}.{ByteData[i + 3]}";

                if (BitConverter.IsLittleEndian)
                    _port = BitConverter.ToUInt16(new byte[] { ByteData[i + 5], ByteData[i + 4] }, 0);
                else
                    _port = BitConverter.ToUInt16(new byte[] { ByteData[i + 4], ByteData[i + 5] }, 0);

                A.Add(new IPEndPoint(IPAddress.Parse(_ip), _port));
            }
            return A.Distinct().ToList();
        }
    }
}
