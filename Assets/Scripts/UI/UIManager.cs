using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{

    [SerializeField]
    public Layer currentLayer;
    public Layer rootLayer;
    
    [Header("Inventory")]
    [SerializeField] private GameObject background;
    
    [SerializeField] private GameObject backpackBar;
    public ContainerUI bagContainer;


    [SerializeField] private GameObject equipmentBar;
    private ContainerUI equipmentContainer;
    [SerializeField] private GameObject chestBar;

    [SerializeField] private GameObject bottomBar;
    public SlotHolder[] actionSlots;

    private bool isBag = false;

    protected override void Awake()
    {
        base.Awake();
        rootLayer = gameObject.GetComponent<Layer>();
        
        //DontDestroyOnLoad(this);
        //equipmentContainer = equipmentBar.GetComponentInChildren<ContainerUI>();
    }

    private void Start()
    {
        currentLayer = rootLayer.FindLayer("ButtonLayer");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            OnBag();
        OnActionSlots();
    }



    #region Inventory Show & Hide
    public void OnBag()
    {
        if (isBag)
            HideBag();
        else
            ShowBag();
        isBag = !isBag;
    }

    public void ShowBag()
    {
        updateStatus();

        background.SetActive(true);
        backpackBar.SetActive(true);
        equipmentBar.SetActive(true);
        removeChildUI(chestBar);
    }

    public void HideBag()
    {
        background.SetActive(false);
        backpackBar.SetActive(false);
        equipmentBar.SetActive(false);
        removeChildUI(chestBar);
    }

    public void ShowBackpack()
    {
        background.SetActive(true);
        backpackBar.SetActive(true);
        equipmentBar.SetActive(false);
    }

    public void HideBackpack()
    {
        background.SetActive(false);
        backpackBar.SetActive(false);
        equipmentBar.SetActive(false);
        removeChildUI(chestBar);
    }

    public void ShowActionBar()
    {
        bottomBar.SetActive(true);
    }

    public void HideActionBar()
    {
        bottomBar.SetActive(false);
    }

    #endregion


    #region EquipmentSlot
    public void updateStatus()
    {
        
    }
    #endregion


    #region ActionSlot
    public void OnActionSlots()
    {
        for(int i = 0; i < actionSlots.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                actionSlots[i].UseItem();
            }
        }
    }
    #endregion


    #region util
    public void SetUp()
    {
        //gameObject.GetComponentInChildren<MainMenuWindow>().menu.SetActive(false);
    }

    private bool InteractWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }
        else
            return false;
    }

    public void removeChildUI(GameObject g)
    {
        foreach (Transform child in g.transform)
        {
            Destroy(child.gameObject);
        }
    }

    #endregion

}