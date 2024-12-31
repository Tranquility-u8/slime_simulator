using System;
using System.IO;
using UnityEngine;

[Serializable]
public class CorePath
{
    #region members
    public static string rootPath
    {
        get
        {
            return Application.persistentDataPath + "/Faded" ;
        }
    }

    public static string tempPath
    {
        get
        {
            return rootPath + "/Temp" ;
        }
    }

    public static string configPath
    {
        get
        {
            return rootPath + "/config.txt" ;
        }
    }

    public static string versionPath
    {
        get
        {
            return rootPath + "/version.txt" ;
        }
    }
    
    #endregion

    #region methods
    public static void Init()
    {
        #if UNITY_EDITOR
        Debug.Log("CorePath.Init");
        #endif
    }
    #endregion
    
}
