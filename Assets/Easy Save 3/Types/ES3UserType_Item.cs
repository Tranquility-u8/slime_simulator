using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("itemType", "itemState", "id", "name")]
	public class ES3UserType_Item : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Item() : base(typeof(Item)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (Item)obj;
			
			writer.WritePropertyByRef("itemType", instance.itemType);
			writer.WriteProperty("itemState", instance.itemState, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(ItemState)));
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (Item)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "itemType":
						instance.itemType = reader.Read<ItemTypeSO>();
						break;
					case "itemState":
						instance.itemState = reader.Read<ItemState>();
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
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new Item();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_ItemArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemArray() : base(typeof(Item[]), ES3UserType_Item.Instance)
		{
			Instance = this;
		}
	}
}