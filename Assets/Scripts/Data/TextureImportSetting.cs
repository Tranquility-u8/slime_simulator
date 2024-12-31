using System;
using UnityEngine;

public class TextureImportSetting : Singleton<TextureImportSetting>
{
    
    public TextureImportSetting.Data data;
    
    [Serializable]
    public class Data
    {
        public TextureFormat format = TextureFormat.ARGB32;
        
        public TextureWrapMode wrapMode;
        
        public FilterMode filterMode;
        
        public bool linear;

        public bool mipmap;
        
        public bool alphaIsTransparency = true;
        
        public bool fixTranparency;
        
        public int anisoLevel;
        
        public int mipmapBias;
    }
}