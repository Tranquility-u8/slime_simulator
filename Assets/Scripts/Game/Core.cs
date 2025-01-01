using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

public class Core : Singleton<Core>
{
    #region members
    
    public EventSystem eventSystem;
    
    public CoreConfig coreConfig;
    
    public Game game;
    
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
    
    public Zone currentZone;

    #endregion
    
    # region methods

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Core Awake");
        // TODO: IO init
        // TODO: Language init
        // TODO: Variable init
        // TODO: SteamWork init
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
        
        this.scene.Init(Scene.SceneType.Zone);

        this.currentZone = game.world.atlases[0]?.zones["Village"];

        // Init terrain
        Debug.Log("Create terrain");
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                this.currentZone.PlaceItem(new Item("Grass", this.currentZone, i, j, 0));
            }
        }
        
        // Init PC
        Debug.Log("Create pc");
        Character pc = new PC(this.currentZone, 0, 0, 0);
        
        this.currentZone.AddCharacter(pc);
        
        this.currentZone.Render();
        

    }

    private void Update()
    {
        if (this.deltaTime > 0.1f)
        {
            this.deltaTime = 0.1f;
        }
        SSInput.deltaTime = this.deltaTime;
        if (IsGameStarted)
        {
            this.game.OnUpdate();
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
