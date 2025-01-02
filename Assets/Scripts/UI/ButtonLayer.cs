using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonLayer: Layer
{
    [SerializeField] 
    private List<Button> buttons = new List<Button>();

    private int currentButton;
    
    private int buttonNum;
    
    [SerializeField]
    private Transform arrow;
    
    [FormerlySerializedAs("arrowStep")] [SerializeField]
    private Vector3 arrowStepDown;

    private new void Start()
    {
        base.Start();
        buttonNum = buttons.Count;
        currentButton = 0;
    }
    
    public override void OnPrev()
    {
        if (currentButton > 0)
        {
            currentButton--;
            arrow.transform.Translate(-arrowStepDown);
        }
    }
    
    public override void OnNext()
    {
        if (currentButton < buttonNum - 1)
        {
            currentButton++;
            arrow.transform.Translate(arrowStepDown);
        }
    }

    public override void OnClick()
    {
        buttons[currentButton].onClick.Invoke();
    }
    
}