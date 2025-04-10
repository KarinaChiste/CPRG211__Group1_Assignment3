﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CPRG211__Group1_Assignment3
{
    public static class SerializationHelper
    {
        public static void SerializeUsers(List<User> users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        public static List<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (List<User>)serializer.ReadObject(stream);
            }
        }

        public static void OrderUsers (List<User> users)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-9.0 used the sort method as defined here
            users.Sort(delegate (User x, User y)
            {
                return x.Name.CompareTo(y.Name);
            });


            
        }

    }
}
