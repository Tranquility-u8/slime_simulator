using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;
using Newtonsoft.Json;

public class Game
{
    #region members
    
    [JsonIgnore]
    public bool IsInitialized { get; set; }
    
    [JsonIgnore]
    public GameUpdater GameUpdater { get; private set; }
    
    [JsonIgnore]
    public Character PC { get; set; }
    
    public World World { get; private set; }
    
    public Zone CurrentZone { get; set; }
    
    public DateTime Date { get; set; }
    
    public WeatherType currentWeather;
    
    [JsonIgnore]
    public float WaitTimer { get; private set; }
    
    [JsonIgnore]
    public float WaitTime { get; private set; }
    
    [JsonIgnore]
    public bool IsPaused { get; private set; }
    
    public string Id { get; set; }
    
    public float BackupTime { get; private set; }
    
    public List<int> list = new List<int>(){1,2,3,4,5,6,7,8,9,10,11};
    
    #endregion
    
    #region methods
    
    public void Init(Character _pc)
    {
        if (_pc == null)
        {
            Debug.LogWarning("Null pc");
            return;
        }
        
        GameUpdater = new GameUpdater(_pc);
        IsInitialized = true;
    }

    public void OnLoad(Character _pc)
    {
        GameUpdater = new GameUpdater(_pc);
        IsInitialized = true;
    }
    
    public void OnUpdate()
    {
        if (!IsInitialized)
        {
            Debug.LogWarning("Game not initialized");
            return;
        }
        
        this.BackupTime += Time.deltaTime;
        this.GameUpdater.FixedUpdate();
    }
    
    public void StartNewGame()
    {
        World = new World();
    }
    
    
    public void UpdateView()
    {
        this.CurrentZone.Render();
    }
    
    #endregion

}

public enum SeasonType{
    Spring,
    Summer,
    Autumn,
    Winter
}

[JsonObject(MemberSerialization.OptIn)]
public static class Season
{
    public static SeasonType GetSeasonType(DateTime date)
    {
        if(date.Month >= 1 && date.Month <= 3)
            return SeasonType.Spring;
        if(date.Month >= 4 && date.Month <= 6)
            return SeasonType.Summer;
        if(date.Month >= 7 && date.Month <= 9)
            return SeasonType.Autumn;
        
        return SeasonType.Winter;
    }
}

[JsonObject(MemberSerialization.OptIn)]
public static class Weather
{
    public static WeatherType GetRandomWeather()
    {
        // TODO:
        return WeatherType.Normal;
    }
}

public enum WeatherType
{
    Normal,
    Rain,
    HeavyRain,
    Snow,
    HeavySnow,
}