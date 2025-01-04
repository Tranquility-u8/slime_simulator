using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("x", "y", "z", "id")]
	public class ES3UserType_Cell3d : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Cell3d() : base(typeof(Cell3d)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Cell3d)obj;
			
			writer.WriteProperty("x", instance.x, ES3Type_int.Instance);
			writer.WriteProperty("y", instance.y, ES3Type_int.Instance);
			writer.WriteProperty("z", instance.z, ES3Type_int.Instance);
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Cell3d)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "x":
						instance.x = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "y":
						instance.y = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "z":
						instance.z = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "id":
						instance.id = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Cell3d();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_Cell3dArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_Cell3dArray() : base(typeof(Cell3d[]), ES3UserType_Cell3d.Instance)
		{
			Instance = this;
		}
	}
}