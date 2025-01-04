using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("id", "name")]
	public class ES3UserType_Entity : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Entity() : base(typeof(Entity)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Entity)obj;
			
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Entity)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "id":
						instance.id = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "name":
						instance.name = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Entity();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_EntityArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_EntityArray() : base(typeof(Entity[]), ES3UserType_Entity.Instance)
		{
			Instance = this;
		}
	}
}