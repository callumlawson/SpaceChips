using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Simulation.Components;
using Assets.Scripts.Simulation.Components.Digital.LogicGates;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class ChipEditor
    {
        public ChipEditor()
        {
            TestJsonWriter();

            IEnumerable<Type> chipTypes = GetChipTypes();
            //chipTypes.ToList().ForEach(t => Debug.Log(t.FullName));
        }

        private void TestJsonWriter()
        {
            using (var streamWriter = new StreamWriter("Assets/test.txt"))
            {
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartArray();
                    foreach (Type type in GetChipTypes())
                    {
                        WriteChipTypeToJson(writer, type);
                    }
                    writer.WriteEndArray();
                }
            }
        }

        private void WriteChipTypeToJson(JsonWriter writer, Type type)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ChipType");
            writer.WriteValue(type.FullName);
            writer.WriteEndObject();
        }

        private void TestSerialization()
        {
            string serialized = JsonConvert.SerializeObject(new And(null, null, null, null), Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            Debug.Log(serialized);
        }

        private static IEnumerable<Type> GetChipTypes()
        {
            return from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsClass && type.IsSubclassOf(typeof (Chip))
                select type;
        }
    }
}