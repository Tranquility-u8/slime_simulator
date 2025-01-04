using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("itemInstalled", "itemDropped", "character", "x", "y", "z", "id")]
	public class ES3UserType_Cube : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Cube() : base(typeof(Cube)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Cube)obj;
			
			writer.WritePrivateField("itemInstalled", instance);
			writer.WritePrivateField("itemDropped", instance);
			writer.WritePrivateField("character", instance);
			writer.WriteProperty("x", instance.x, ES3Type_int.Instance);
			writer.WriteProperty("y", instance.y, ES3Type_int.Instance);
			writer.WriteProperty("z", instance.z, ES3Type_int.Instance);
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Cube)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "itemInstalled":
					instance = (Cube)reader.SetPrivateField("itemInstalled", reader.Read<Item>(), instance);
					if (instance.IsInstalled)
					{
						instance.ItemInstalled.cube = instance;
					}
					break;
					case "itemDropped":
					instance = (Cube)reader.SetPrivateField("itemDropped", reader.Read<System.Collections.Generic.List<Item>>(), instance);
					break;
					case "character":
					instance = (Cube)reader.SetPrivateField("character", reader.Read<Character>(), instance);
					if (instance.IsOccupied)
					{
						instance.Character.cube = instance;
					}
					break;
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
			var instance = new Cube();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_CubeArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CubeArray() : base(typeof(Cube[]), ES3UserType_Cube.Instance)
		{
			Instance = this;
		}
	}
}