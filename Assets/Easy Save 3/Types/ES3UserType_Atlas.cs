using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("size", "zones", "sizeX", "sizeY", "grid", "name", "renderAnchor", "renderSize")]
	public class ES3UserType_Atlas : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Atlas() : base(typeof(Atlas)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Atlas)obj;
			
			writer.WriteProperty("size", instance.size, ES3Type_Vector2.Instance);
			writer.WriteProperty("zones", instance.zones, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.Dictionary<System.String, Zone>)));
			writer.WriteProperty("sizeX", instance.sizeX, ES3Type_int.Instance);
			writer.WriteProperty("sizeY", instance.sizeY, ES3Type_int.Instance);
			writer.WriteProperty("grid", instance.grid, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Tile[,])));
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
			writer.WriteProperty("renderAnchor", instance.renderAnchor, ES3Type_Vector2Int.Instance);
			writer.WriteProperty("renderSize", instance.renderSize, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Atlas)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "size":
						instance.size = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					case "zones":
						instance.zones = reader.Read<System.Collections.Generic.Dictionary<System.String, Zone>>();
						break;
					case "sizeX":
						instance.sizeX = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "sizeY":
						instance.sizeY = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "grid":
						instance.grid = reader.Read<Tile[,]>();
						break;
					case "name":
						instance.name = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "renderAnchor":
						instance.renderAnchor = reader.Read<UnityEngine.Vector2Int>(ES3Type_Vector2Int.Instance);
						break;
					case "renderSize":
						instance.renderSize = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Atlas();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_AtlasArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AtlasArray() : base(typeof(Atlas[]), ES3UserType_Atlas.Instance)
		{
			Instance = this;
		}
	}
}