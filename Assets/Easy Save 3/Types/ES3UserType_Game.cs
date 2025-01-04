using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("currentWeather", "list", "World", "CurrentZone", "Id", "BackupTime")]
	public class ES3UserType_Game : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Game() : base(typeof(Game)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Game)obj;
			
			writer.WriteProperty("currentWeather", instance.currentWeather, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(WeatherType)));
			writer.WriteProperty("list", instance.list, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Int32>)));
			writer.WritePrivateProperty("World", instance);
			writer.WriteProperty("CurrentZone", instance.CurrentZone, ES3UserType_Zone.Instance);
			writer.WriteProperty("Id", instance.Id, ES3Type_string.Instance);
			writer.WritePrivateProperty("BackupTime", instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Game)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "currentWeather":
						instance.currentWeather = reader.Read<WeatherType>();
						break;
					case "list":
						instance.list = reader.Read<System.Collections.Generic.List<System.Int32>>();
						break;
					case "World":
					instance = (Game)reader.SetPrivateProperty("World", reader.Read<World>(), instance);
					break;
					case "CurrentZone":
						instance.CurrentZone = reader.Read<Zone>(ES3UserType_Zone.Instance);
						break;
					case "Id":
						instance.Id = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "BackupTime":
					instance = (Game)reader.SetPrivateProperty("BackupTime", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Game();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_GameArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameArray() : base(typeof(Game[]), ES3UserType_Game.Instance)
		{
			Instance = this;
		}
	}
}