using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SSInput : MonoBehaviour
{
    #region members

    public static SSAction action;
    
    public static float deltaTime;

    public static Vector3 mposMouse;
    
    public static Vector3 mposWorld;
    
    public static bool hasMouseMoved;
    
    public static Vector2 axis;
    
    public static bool hasAxisMoved;

    public static float wheel;
    
    public static float dragMargin = 32f;
    
    public static float clickDuration = 0.3f;
    
    public static float missClickDuration = 0.3f;

    public static bool isInputFieldActive;

    public static bool isShiftDown;
    
    public static bool isCtrlDown;
    
    public static bool isAltDown;

    public static int hotkey;

    public static int functionkey;
    
    #endregion
    
    #region methods

    public void Update()
    {    
        SSInput.missClickDuration -= SSInput.deltaTime;
        SSInput.mposMouse = Input.mousePosition;
        if (Camera.main)
        {
            SSInput.mposWorld = Camera.main.ScreenToWorldPoint(SSInput.mposMouse);
        }
        SSInput.mposWorld.z = 0f;
        
        SSInput.axis = Vector2.zero;
        SSInput.hasAxisMoved = (SSInput.hasMouseMoved = false);
        SSInput.wheel = 0;
        
        SSInput.action = SSAction.None;
        
        if (!Application.isFocused) return;
        
        EventSystem current = EventSystem.current;
        GameObject gameObject = (current != null) ? current.currentSelectedGameObject : null;
        if (gameObject && gameObject.activeInHierarchy)
        {
            SSInput.isInputFieldActive = gameObject.GetComponent<InputField>();
        }
        else
        {
            SSInput.isInputFieldActive = false;
        }
        
        SSInput.isShiftDown = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        SSInput.isCtrlDown = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
        SSInput.isAltDown = (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt));
        
        SSInput.hotkey = SSInput.GetHotkeyDown();
        SSInput.functionkey = SSInput.GetFunctionkeyDown();
        SSInput.action = SSInput.GetAction();
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
    
    private static SSAction GetAction()
    {
        string inputString = Input.inputString;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return SSAction.Wait;
        }
        
        if (!SSInput.isShiftDown)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return SSAction.MenuChara;
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                return SSAction.MenuInventory;
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                return SSAction.QuickSave;
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                return SSAction.QuickLoad;
            }
            if(Input.GetKeyDown(KeyCode.W))
            {
                return SSAction.AxisUp;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                return SSAction.AxisDown;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                return SSAction.AxisLeft;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                return SSAction.AxisRight;
            }
        }
        return SSAction.None;
    }
    #endregion
    
    // TODO: Add Custom keyMap
}
