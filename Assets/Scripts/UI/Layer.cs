using System;
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;  

public class Layer : MonoBehaviour  
{  
    private List<Layer> subLayers = new List<Layer>();

    private void Awake()
    {
        Layer[] children = gameObject.GetComponentsInChildren<Layer>(true);
        foreach (var subLayer in children)
        {
            subLayers.Add(subLayer);
        }
    }

    protected void Start()
    {
    
    }

    public virtual void Show()  
    {  
        gameObject.SetActive(true); 
    }  
    
    public virtual void Hide()  
    {  
        gameObject.SetActive(false);  
    }

    public virtual void OnPrev()
    {
        
    }

    public virtual void OnNext()
    {
        
    }

    public virtual void OnClick()
    {
        
    }
    
    public void SwitchToLayer(Layer newLayer)  
    {  
        Hide();            
        newLayer.Show();     
    }  
    
    public Layer FindLayer(string layerName)  
    {  
        foreach (Layer layer in subLayers)  
        {  
            if (layer.gameObject.name == layerName)  
            {  
                return layer;  
            }  
        }  
        return null; 
    }  
}