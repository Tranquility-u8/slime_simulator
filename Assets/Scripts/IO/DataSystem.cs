using System.IO;
using UnityEngine;


public static class DataSystem
{
    public static string dataDirectory = "/save";

    public static void SaveByJson(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName); ;

        try
        {

            File.WriteAllText(path, json);

        }
        catch (System.Exception exception)
        {
            Debug.Log( $"Save by json error in ${path}");
            Debug.Log(exception.Message);
        }
    }

    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory, saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);
            
            return data;
        }
        catch (System.Exception exception)
        {
            Debug.Log("Load from json error");
            Debug.Log(exception.Message);
            return default;
        }
    }

    public static void LoadFromJsonOverwrite<T>(string saveFileName, T savedData)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName);
        try
        {
            var json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, savedData);
            
        }
        catch (System.Exception exception)
        {
            Debug.Log("Load from json overwrite error");
            Debug.Log(exception.Message);
        }
    }



    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.dataPath + dataDirectory,  saveFileName);

        try
        {
            File.Delete(path);
        }
        catch (System.Exception exception)
        {
            Debug.Log("Delete save file error");
            Debug.Log(exception.Message);
        }
    }

    public static T DeepCopy<T>(T so) where T : ScriptableObject
    {
        if (so == null)
            return null;

        string json = JsonUtility.ToJson(so);
        T clone = ScriptableObject.CreateInstance<T>();
        JsonUtility.FromJsonOverwrite(json, clone);

        return clone;
    }
}
