using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("speed", "actionTimer", "actionMaxTime", "actionPoint", "id", "name")]
	public class ES3UserType_Character : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Character() : base(typeof(Character)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Character)obj;
			
			writer.WritePrivateField("speed", instance);
			writer.WriteProperty("actionTimer", instance.actionTimer, ES3Type_float.Instance);
			writer.WriteProperty("actionMaxTime", instance.actionMaxTime, ES3Type_float.Instance);
			writer.WriteProperty("actionPoint", instance.actionPoint, ES3Type_int.Instance);
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Character)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					case "speed":
						instance = (Character)reader.SetPrivateField("speed", reader.Read<System.Single>(), instance);
					break;
					case "actionTimer":
						instance.actionTimer = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "actionMaxTime":
						instance.actionMaxTime = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "actionPoint":
						instance.actionPoint = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
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
			instance.characterType = EntityData.Instance.GetCharacterTypeByName(instance.name);
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Character();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_CharacterArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CharacterArray() : base(typeof(Character[]), ES3UserType_Character.Instance)
		{
			Instance = this;
		}
	}
}