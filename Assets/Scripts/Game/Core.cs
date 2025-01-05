using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;
using Logger = UnityEngine.Logger;

public class Core : Singleton<Core>
{
    #region members
    
    public EventSystem eventSystem;
    
    public CoreConfig coreConfig;
    
    public Game game;
    
    public GameUpdater gameUpdater;
    
    public Scene scene;
    
    public Canvas canvas;
    
    public float deltaTime;
    
    public bool isPaused = false;
 
    public bool IsGameStarted
    {
        get
        {
            return this.game != null;
        }
    }
    public bool isLoading;
    
    public World world;

    #endregion
    
    # region methods

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Core Awake");
        // TODO: IO Init
        // TODO: Language Init
        // TODO: Variable Init
        // TODO: SteamWork Init
    }

    private void Start()
    {
        this.Init();
    }

    private void Init()
    {
        Debug.Log("Core Init");
        
        // TODO: Load config from dirs
        Debug.Log("Loading core config");
        CoreConfig config = new CoreConfig();
        this.coreConfig = config;
        
        // Test new game
        Debug.Log("Create new game");
        this.game = new Game();
        this.game.StartNewGame();
        
        this.game.CurrentZone = game.World.atlases[0].zones["Village"];

        // Init terrain
        Debug.Log("Create terrain");
        
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                this.game.CurrentZone.PlaceItem(new Item("Grass"), i, j, 0);
            }
        }
        
        this.game.CurrentZone.PlaceItem(new Item("Grass"), 4, 3, 1);
        this.game.CurrentZone.PlaceItem(new Item("Grass"), 5, 3, 1);
        
        this.game.CurrentZone.PlaceItem(new Item("Tree"), 1, 2, 1);
        
        // Create PC (Slime)
        Debug.Log("Create pc");
        Character pc = new PC();
        this.game.CurrentZone.AddCharacter(pc,4, 1, 1);
        pc.Speed = 150;
        
        // Create witch
        /*
        Debug.Log("Create witch");
        Character witch = new Character("Witch");
        this.currentZone.AddCharacter(witch, 4, 2, 1);
        */
        
        // Create paragon
        Debug.Log("Create paragon");
        Character paragon = new Character("Paragon");
        paragon.AI = new AI_Monster();
        this.game.CurrentZone.AddCharacter(paragon, 0, 0, 1);
        
        // Create grym
        Debug.Log("Create grym");
        Character grym = new Character("Grym");
        grym.AI = new AI_Monster();
        this.game.CurrentZone.AddCharacter(grym, 2, 4, 1);
        
        // Render zone
        this.game.CurrentZone.Render();
        
        this.game.Init(pc);
        
        this.gameUpdater = this.game.GameUpdater;

    }

    private void Update()
    {
        if (this.deltaTime > 0.1f)
        {
            this.deltaTime = 0.1f;
        }
        Test();
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
                SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
                LoadGame();
        }
    }
    
    
    public void SaveGame()
    {
        if (this.game == null)
        {
            Debug.LogWarning("Game is null");
            return;
        }
        ES3.Save("test", this.game, "SaveFile.es3" );
        Debug.Log("Save game");
    }

    public void LoadGame()
    {
        ClearGameView(this.game);
        this.game = (Game)ES3.Load("test", game);
        if (game != null)
        {
            Debug.Log("Load game");
            game.CurrentZone = game.World.atlases[0].zones["Village"];
            game.CurrentZone.OnLoadAfter();
            this.game.UpdateView();
        }
    }

    public void ClearGameView(Game _game)
    {
        Zone _zone = _game.CurrentZone;
        foreach (var term in _zone.charactersDict)
        {
            Destroy(term.Value.gameObject);
        }

        
        for (int i = 0; i < _zone.sizeX; i++)
        {
            for (int j = 0; j < _zone.sizeY; j++)
            {
                for (int k = 0; k < _zone.sizeZ; k++)
                {
                    Cube cube = _zone.grid[i, j, k];
                    if(cube.IsInstalled)
                        Destroy(cube.ItemInstalled.gameObject);
                }
                            
            }
        }
    }
    
    public void WaitForEndOfFrame(Action action)
    {
        base.StartCoroutine(this._WaitForEndOfFrame(action));
    }
    
    private IEnumerator _WaitForEndOfFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action();
        yield break;
    }
    
    public virtual void StopEventSystem(float duration = 0.2f)
    {
    }
    
    public virtual void StopEventSystem(Component c, Action action, float duration = 0.2f)
    {
    }
    # endregion methods
}
