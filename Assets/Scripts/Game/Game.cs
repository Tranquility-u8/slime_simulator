using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class Game
{
    #region members
    
    public static Game Instance;
    
    public GameUpdater gameUpdater = new GameUpdater();
    
    [JsonProperty]
    public World world;
    
    [JsonProperty]
    public DateTime dateTime;
    
    [JsonProperty]
    public WeatherType currentWeather;
    
    public static float waitTimer;
    
    public static bool isPaused;
    
    [JsonProperty]
    public static string id;
    
    [JsonProperty]
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

[Serializable]
public class DateTime
{
    public int year;
    public int month;
    public int day;
    public int hour;
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
        if(date.month >= 1 && date.month <= 3)
            return SeasonType.Spring;
        if(date.month >= 4 && date.month <= 6)
            return SeasonType.Summer;
        if(date.month >= 7 && date.month <= 9)
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