using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("name", "atlases")]
	public class ES3UserType_World : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_World() : base(typeof(World)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (World)obj;
			
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
			writer.WriteProperty("atlases", instance.atlases, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<Atlas>)));
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (World)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "name":
						instance.name = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "atlases":
						instance.atlases = reader.Read<System.Collections.Generic.List<Atlas>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new World();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_WorldArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorldArray() : base(typeof(World[]), ES3UserType_World.Instance)
		{
			Instance = this;
		}
	}
}