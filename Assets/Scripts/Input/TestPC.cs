using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPC : MonoBehaviour
{
    public Transform pc;
    
    void Start()
    {
        pc = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        switch (SSInput.action)
        {
            case SSAction.AxisLeft:
                pc.Translate(Vector3.left);
                break;
            case SSAction.AxisRight:
                pc.Translate(Vector3.right);
                break;
            case SSAction.AxisUp:
                pc.Translate(Vector3.up);
                break;
            case SSAction.AxisDown:
                pc.Translate(Vector3.down);
                break;
        }
        
    }
}
