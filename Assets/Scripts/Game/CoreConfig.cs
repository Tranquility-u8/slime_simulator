using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
[JsonObject(MemberSerialization.OptIn)]
public class CoreConfig
{
    #region members

    public static string path
    {
        get
        {
            return CorePath.configPath;
        }
    }

    #endregion

    #region methods

    public static CoreConfig LoadConfig()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("CoreConfig file could not be found at " + path);
            return null;
        }

        CoreConfig coreConfig = IO.LoadFile<CoreConfig>(path, null);
        return coreConfig;
    }

    public void Apply()
    {
        
    }
    #endregion
    
}