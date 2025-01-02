using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    #region members
    public SceneType sceneType;
    //public Camera camera;
//    public Tileset tileset;
    public SpriteRenderer srTarget;
    public ParticleSystem psSmoke;
    public ParticleSystem psRainSplash;
    

    #endregion

    public void Init(SceneType _sceneType)
    {
        sceneType = _sceneType;
        switch (_sceneType)
        {
        case SceneType.None:
            // TODO
            break;
        case SceneType.Title:
            // TODO
            break;
        case SceneType.Zone:
            // TODO: Player Init
            
            // TODO: World Init
            
            // TODO: Screen and UI Init
            break;
        
        }
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    public enum SceneType
    {
        None,
        Title,
        Zone
    }
}
