using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game
{
    #region members
    
    public static Game Instance;
    
    public GameUpdater gameUpdater = new GameUpdater();
    
    public static float waitTimer;
    
    public static string id;
    
    public static bool isPaused;
    
    public double backupTime;
    
    #endregion
    
    #region methods

    public void OnUpdate()
    {
        this.backupTime += (double)Time.deltaTime;
        this.gameUpdater.FixedUpdate();
    }

    public void StartNewGame()
    {
        
    }
    
    #endregion

}
