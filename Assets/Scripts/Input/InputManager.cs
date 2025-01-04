using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;


/// <summary>
/// Input => InputMode => SSAction => Input ......
/// eg: Input: Press "W" => At InputMode: Waiting =>
/// Conduct SSAction: MoveUp and Set InputMode: Waiting
/// </summary>
public class InputManager : Singleton<InputManager>
{
    #region members
    
    private Transform trans;
    
    public bool isInitialized = false;
    
    [Header("InputMode")]
    public InputMode inputMode;
    
    [Header("SSActions")]
    public SSAction lastSSAction;
    
    public SSAction currentSSAction;
    
    [Header("Frame")]
    public float deltaTime;

    [Header("Input: Mouse")]
    public Vector3 mousePos;
    
    public Vector3 mousePosWorld;
    
    public bool hasMouseMoved;
    
    public Vector2 axis;
    
    public bool hasAxisMoved;

    public float wheel;
    
    public float dragMargin = 32f;
    
    public float clickDuration = 0.3f;
    
    public float missClickDuration = 0.3f;
    
    [Header("Input: Keyboard")]
    public bool isAltDown;
    
    public bool isCtrlDown;
    
    public  bool isShiftDown;

    public int hotkey;

    public int functionkey;
    
    #endregion
    
    #region methods

    public void Update()
    {    
        if (!Application.isFocused) return;
        
        // Input: Mouse
        Instance.deltaTime = Time.deltaTime;
        Instance.mousePos = Input.mousePosition;
        if (Camera.main)
        {
            Instance.mousePosWorld = Camera.main.ScreenToWorldPoint(Instance.mousePos);
        }
        else
        {
            Debug.LogWarning("No main camera found");
        }
        Instance.mousePosWorld.z = 0f;
        Instance.hasMouseMoved = false;
        Instance.wheel = 0;
        
        Instance.axis = Vector2.zero;
        Instance.hasAxisMoved = false;

        Instance.missClickDuration -= Instance.deltaTime;

        // Input: Keyboard
        Instance.isAltDown = (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt));
        Instance.isCtrlDown = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
        Instance.isShiftDown = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        
        Instance.hotkey = InputManager.GetHotkeyDown();
        Instance.functionkey = InputManager.GetFunctionkeyDown();

        // GetAction
        SSAction newAction = GetAction();
        if(newAction == SSAction.None) return;
        
        lastSSAction = currentSSAction;
        currentSSAction = newAction;
        ConductAction(currentSSAction);
    }
    
    #endregion

    #region helpers
    public static int GetHotkeyDown()
    {
        int result = -1;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            result = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            result = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            result = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            result = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            result = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            result = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            result = 6;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            result = 7;
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            result = 8;
        }
        return result;
    }
    
    public static int GetFunctionkeyDown()
    {
        int result = -1;
        if (Input.GetKeyDown(KeyCode.F1))
        {
            result = 0;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            result = 1;
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            result = 2;
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            result = 3;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            result = 4;
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            result = 5;
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            result = 6;
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            result = 7;
        }
        return result;
    }
    
    private SSAction GetAction()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return SSAction.Confirm;
        }
        switch (inputMode)
        {
            case InputMode.Waiting:
                if(Input.GetKeyDown(KeyCode.W))
                {
                    return SSAction.MoveUp;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    return SSAction.MoveDown;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    return SSAction.MoveLeft;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    return SSAction.MoveRight;
                }
                if (Input.GetKeyDown(KeyCode.F6))
                {
                    return SSAction.QuickSave;
                }
                if (Input.GetKeyDown(KeyCode.F7))
                {
                    return SSAction.QuickLoad;
                }

                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    return SSAction.OpenInventory;
                }
                break;
            case InputMode.OnInventory:
                break;
            case InputMode.OnJournal:
                break;
            case InputMode.OnTitle:
                if(Input.GetKeyDown(KeyCode.W))
                {
                    return SSAction.Prev;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    return SSAction.Next;
                }
                break;
            case InputMode.OnMainMenu:
                break;
            default:
                break;
        }
        return SSAction.None;
    }

    private void ConductAction(SSAction action)
    {
        if (action >= SSAction.MoveUp && action <= SSAction.MoveLeft)
        {
            ActionHelper.MoveTowards(Core.Instance.game.PC, (int)action - (int)SSAction.MoveUp);
            Core.Instance.gameUpdater.FixedUpdate();
            return;
        }
        if (action >= SSAction.Wait && action <= SSAction.Fire)
        {
            
            return;
        }
        if (action == SSAction.Prev)
        {
            UIManager.Instance.currentLayer.OnPrev();
            return;
        }
        if (action == SSAction.Next)
        {
            UIManager.Instance.currentLayer.OnNext();
            return;
        }

        if (action == SSAction.Confirm)
        {
            UIManager.Instance.currentLayer.OnClick();
            return;
        }
        
        return;
    } 
    
    #endregion
    
    // TODO: Add Custom keyMap
}
