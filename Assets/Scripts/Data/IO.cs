using System;
using System.IO;
using UnityEngine;
using LZ4;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class IO
{
	public static void OnError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
	{
	}
	
	public static string Serialize(object obj)
	{
		return JsonConvert.SerializeObject(obj, IO.formatting, IO.jsWriteGeneral);
	}
	
	public static T Deserialize<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json, IO.jsReadGeneral);
	}
	
	public static void SaveFile(string path, object obj, bool compress = false, JsonSerializerSettings setting = null)
	{
		string text = JsonConvert.SerializeObject(obj, IO.formatting, setting ?? IO.jsWriteGeneral);
		IO.CreateDirectory(Path.GetDirectoryName(path));
		if (compress)
		{
			IO.Compress(path, text);
			return;
		}
		File.WriteAllText(path, text);
	}
	
	public static void SaveText(string path, string text)
	{
		IO.CreateDirectory(Path.GetDirectoryName(path));
		File.WriteAllText(path, text);
	}
	
	public static T LoadFile<T>(string path, JsonSerializerSettings setting = null)
	{
		if (!File.Exists(path))
		{
			Debug.Log("File does not exist:" + path);
			return default(T);
		}
		string value = IO.IsCompressed(path) ? IO.Decompress(path) : File.ReadAllText(path);
		return JsonConvert.DeserializeObject<T>(value, setting ?? IO.jsReadGeneral);
	}
	
	public static T LoadStreamJson<T>(MemoryStream stream, JsonSerializerSettings setting = null)
	{
		stream.Position = 0L;
		string value = "";
		using (StreamReader streamReader = new StreamReader(stream))
		{
			value = streamReader.ReadToEnd();
		}
		return JsonConvert.DeserializeObject<T>(value, setting ?? IO.jsReadGeneral);
	}
	
	public static void WriteLZ4(string _path, byte[] _bytes)
	{
		for (int i = 0; i < 5; i++)
		{
			string path = _path + ((i == 0) ? "" : (".b" + i.ToString()));
			try
			{
				File.WriteAllBytes(path, _bytes);
				break;
			}
			catch (Exception message)
			{
				Debug.Log(message);
			}
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000BA6C File Offset: 0x00009C6C
	public static byte[] ReadLZ4(string _path, int size, IO.Compression compression)
	{
		for (int i = 0; i < 5; i++)
		{
			string text = _path + ((i == 0) ? "" : (".b" + i.ToString()));
			if (!File.Exists(text))
			{
				Debug.Log("Couldn't find:" + text);
			}
			else
			{
				byte[] array = File.ReadAllBytes(text);
				if (array.Length == size)
				{
					return array;
				}
				if (compression == IO.Compression.LZ4)
				{
					try
					{
						return IO.ReadLZ4(array);
					}
					catch (Exception message)
					{
						Debug.Log(message);
					}
				}
			}
		}
		return null;
	}
	
	public static byte[] ReadLZ4(byte[] bytes)
	{
		try
		{
			return LZ4Codec.Unwrap(bytes, 0);
		}
		catch
		{
			Debug.Log("Exception: Failed to unwrap:");
		}
		return bytes;
	}
	
	public static bool IsCompressed(string path)
	{
		byte[] array;
		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(path)))
		{
			binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
			array = binaryReader.ReadBytes(4);
		}
		return array.Length <= 3 || array[0] != 123 || array[1] != 13 || array[2] != 10 || array[3] != 32;
	}
	
	public static void Compress(string path, string text)
	{
		File.WriteAllText(path, text);
	}
	
	public static string Decompress(string path)
	{
		try
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				using (LZ4Stream lz4Stream = new LZ4Stream(fileStream, LZ4StreamMode.Decompress, LZ4StreamFlags.None, 1048576))
				{
					using (StreamReader streamReader = new StreamReader(lz4Stream))
					{
						return streamReader.ReadToEnd();
					}
				}
			}
		}
		catch (Exception message)
		{
			Debug.Log(message);
		}
		Debug.Log("Cannot decompress:" + IO.IsCompressed(path).ToString() + "/" + path);
		string text = File.ReadAllText(path);
		Debug.Log(text);
		return text;
	}
	
	public static void CopyDir(string sourceDirectory, string targetDirectory, Func<string, bool> funcExclude = null)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectory);
		DirectoryInfo target = new DirectoryInfo(targetDirectory);
		if (!directoryInfo.Exists)
		{
			Debug.Log("Source dir doesn't exist:" + directoryInfo.FullName);
			return;
		}
		IO._CopyDir(directoryInfo, target, funcExclude);
	}
	
	public static void _CopyDir(DirectoryInfo source, DirectoryInfo target, Func<string, bool> funcExclude = null)
	{
		if (funcExclude != null && funcExclude(source.Name))
		{
			return;
		}
		Directory.CreateDirectory(target.FullName);
		foreach (FileInfo fileInfo in source.GetFiles())
		{
			fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
		}
		foreach (DirectoryInfo directoryInfo in source.GetDirectories())
		{
			DirectoryInfo target2 = target.CreateSubdirectory(directoryInfo.Name);
			IO._CopyDir(directoryInfo, target2, funcExclude);
		}
	}
	
	public static void Copy(string fromPath, string toPath)
	{
		if (!File.Exists(fromPath))
		{
			Debug.Log("File does not exist:" + fromPath);
			return;
		}
		FileInfo fileInfo = new FileInfo(fromPath);
		DirectoryInfo directoryInfo = new DirectoryInfo(toPath);
		if (!Directory.Exists(directoryInfo.FullName))
		{
			IO.CreateDirectory(directoryInfo.FullName);
		}
		File.Copy(fileInfo.FullName, directoryInfo.FullName + "/" + fileInfo.Name, true);
	}
	
	public static void CopyAs(string fromPath, string toPath)
	{
		if (!File.Exists(fromPath))
		{
			Debug.LogError("File does not exist:" + fromPath);
			return;
		}
		File.Copy(fromPath, toPath, true);
	}
	
	public static void CopyAll(string fromPath, string toPath, bool overwrite = true)
	{
		IO.CreateDirectory(toPath);
		string[] array = Directory.GetDirectories(fromPath, "*", SearchOption.AllDirectories);
		for (int i = 0; i < array.Length; i++)
		{
			Directory.CreateDirectory(array[i].Replace(fromPath, toPath));
		}
		foreach (string text in Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories))
		{
			string text2 = text.Replace(fromPath, toPath);
			if (overwrite || !File.Exists(text2))
			{
				File.Copy(text, text2, true);
			}
		}
	}

	public static void DeleteFile(string path)
	{
		if (!File.Exists(path))
		{
			return;
		}
		File.Delete(path);
	}
	
	public static void DeleteFiles(string path)
	{
		if (!Directory.Exists(path))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(path).GetFiles();
		for (int i = 0; i < files.Length; i++)
		{
			files[i].Delete();
		}
	}
	
	public static void CreateDirectory(string path)
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}
	
	public static void DeleteDirectory(string path)
	{
		if (!Directory.Exists(path))
		{
			return;
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		if (directoryInfo.Exists)
		{
			directoryInfo.Delete(true);
		}
	}
	
	public static T Duplicate<T>(T t)
	{
		return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(t, IO.formatting, IO.jsWriteGeneral), IO.jsReadGeneral);
	}
	
	public static string TempPath
	{
		get
		{
			return Application.persistentDataPath + "/Temp";
		}
	}
	
	public static void CreateTempDirectory(string path = null)
	{
		IO.CreateDirectory(path ?? IO.TempPath);
	}
	
	public static void DeleteTempDirectory(string path = null)
	{
		IO.DeleteDirectory(path ?? IO.TempPath);
	}
	
	public static T LoadObject<T>(FileInfo file, object option = null) where T : UnityEngine.Object
	{
		return IO.LoadObject<T>(file.FullName, option);
	}
	
	public static T LoadObject<T>(string _path, object option = null) where T : UnityEngine.Object
	{
		Type typeFromHandle = typeof(T);
		if (typeFromHandle == typeof(Sprite))
		{
			SpriteLoadOption spriteLoadOption = option as SpriteLoadOption;
			Texture2D texture2D = IO.LoadPNG(_path, FilterMode.Point);
			if (!texture2D)
			{
				return default(T);
			}
			return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), (spriteLoadOption == null) ? new Vector2(0.5f, 0f) : spriteLoadOption.pivot, 100f) as T;
		}
		else
		{
			if (typeFromHandle == typeof(Texture2D))
			{
				return IO.LoadPNG(_path, FilterMode.Point) as T;
			}
			if (typeof(ExcelData).IsAssignableFrom(typeFromHandle))
			{
				T t = Activator.CreateInstance<T>();
				(t as ExcelData).path = _path;
				return t;
			}
			if (typeFromHandle == typeof(TextData))
			{
				return new TextData
				{
					lines = File.ReadAllLines(_path)
				} as T;
			}
			return default(T);
		}
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0000C064 File Offset: 0x0000A264
	public static void SavePNG(Texture2D tex, string _path)
	{
		byte[] bytes = tex.EncodeToPNG();
		File.WriteAllBytes(_path, bytes);
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000C080 File Offset: 0x0000A280
	public static Texture2D LoadPNG(string _path, FilterMode filter = FilterMode.Point)
	{
		if (!File.Exists(_path))
		{
			return null;
		}
		byte[] array = IO.ReadPngFile(_path);
		int num = 16;
		int num2 = 0;
		for (int i = 0; i < 4; i++)
		{
			if (num + 1 < array.Length)
			{
				num2 = num2 * 256 + (int)array[num++];
			}
		}
		int num3 = 0;
		for (int j = 0; j < 4; j++)
		{
			if (num + 1 < array.Length)
			{
				num3 = num3 * 256 + (int)array[num++];
			}
		}
		TextureImportSetting.Data data = TextureImportSetting.Instance ? TextureImportSetting.Instance.data : IO.importSetting;
		Texture2D texture2D = new Texture2D(num2, num3, data.format, data.mipmap, data.linear);
		texture2D.LoadImage(array);
		texture2D.wrapMode = data.wrapMode;
		texture2D.filterMode = filter;
		texture2D.anisoLevel = data.anisoLevel;
		texture2D.mipMapBias = (float)data.mipmapBias;
		return texture2D;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0000C168 File Offset: 0x0000A368
	public static byte[] ReadPngFile(string _path)
	{
		FileStream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		BinaryReader binaryReader = new BinaryReader(fileStream);
		byte[] result = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
		binaryReader.Close();
		fileStream.Close();
		return result;
	}
	
	public static T DeepCopy<T>(T target)
	{
		return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(target, IO.dpFormat, IO.dpSetting), IO.dpSetting);
	}
	
	public static string[] LoadTextArray(string _path)
	{
		if (!File.Exists(_path))
		{
			_path += ".txt";
			if (!File.Exists(_path))
			{
				Debug.Log(_path);
				return new string[0];
			}
		}
		return File.ReadAllLines(_path);
	}
	
	public static string LoadText(string _path)
	{
		string[] array = IO.LoadTextArray(_path);
		string text = "";
		foreach (string str in array)
		{
			text = text + str + Environment.NewLine;
		}
		return text;
	}
	
	public static string log;
	
	public static JsonSerializerSettings jsReadGeneral = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		DefaultValueHandling = DefaultValueHandling.Ignore,
		PreserveReferencesHandling = PreserveReferencesHandling.Objects,
		TypeNameHandling = TypeNameHandling.Auto,
		Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(IO.OnError)
	};
	
	public static JsonSerializerSettings jsWriteGeneral = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		DefaultValueHandling = DefaultValueHandling.Ignore,
		PreserveReferencesHandling = PreserveReferencesHandling.Objects,
		TypeNameHandling = TypeNameHandling.Auto,
		ContractResolver = ContractResolver.Instance,
		Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(IO.OnError)
	};
	
	public static JsonSerializerSettings jsWriteConfig = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		DefaultValueHandling = DefaultValueHandling.Populate,
		PreserveReferencesHandling = PreserveReferencesHandling.Objects,
		TypeNameHandling = TypeNameHandling.Auto,
		ContractResolver = ContractResolver.Instance,
		Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(IO.OnError)
	};
	
	public static Formatting formatting = Formatting.Indented;
	
	public static TextureImportSetting.Data importSetting = new TextureImportSetting.Data();
	
	public static JsonSerializerSettings dpSetting = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Ignore,
		DefaultValueHandling = DefaultValueHandling.Include,
		PreserveReferencesHandling = PreserveReferencesHandling.Objects,
		TypeNameHandling = TypeNameHandling.Auto,
		Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(IO.OnError)
	};
	
	public static Formatting dpFormat = Formatting.Indented;
	
	public enum Compression
	{
		LZ4,
		None
	}
}
