using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("id")]
	public class ES3UserType_CellBase : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CellBase() : base(typeof(CellBase)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (CellBase)obj;
			
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (CellBase)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
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
			var instance = new CellBase();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_CellBaseArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CellBaseArray() : base(typeof(CellBase[]), ES3UserType_CellBase.Instance)
		{
			Instance = this;
		}
	}
}