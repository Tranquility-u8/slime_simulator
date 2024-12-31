using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [Header("UI")]
    public Image icon = null;
    public Image icon_dark = null;
    public TextMeshProUGUI amount = null;

    [Header("CD")]
    [SerializeField] private Slider slider;
    private float cd;
    private float progress;
    public bool isValid = true;

    public InventoryData_SO bag { get; set; }
    public int Index { get; set; } = -1;  


    private void Update()
    {
        if (icon == null || isValid) return;

        progress += Time.deltaTime;
        if (progress > cd)
        {
            isValid = true;
            slider.value = 1;
        }
        else
        {
            slider.value = progress / cd;
            if(GetItem() != null)
                GetItem().progress = progress;
        }

    }

    public void ResetCd()
    {
        GetItem().progress = 0;
        isValid = false;
    }

    public void UpdateProgress()
    {
        GetItem().progress = progress;
    } 

    public void UpdateItemUI(ItemData_SO item, int itemAmount)
    {
        if(itemAmount == 0)     //����Ϊ0����Ʒɾ����ͼƬGameobject������
        {
            bag.items[Index].itemData = null;
            icon.gameObject.SetActive(false);
            icon_dark.gameObject.SetActive(false);
            return;
        }
    
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            icon_dark.sprite = item.itemIcon;

            amount.text = itemAmount.ToString();
            icon.gameObject.SetActive(true);
            icon_dark.gameObject.SetActive(true);

            cd = item.cd;
            progress = item.progress;
            if (progress < cd)
                isValid = false;
            else
                isValid = true;
        }
        else 
        {
            icon.gameObject.SetActive(false);
            icon_dark.gameObject.SetActive(false);
        }
    }

    public ItemData_SO GetItem()
    {
        /*
        if(Index == -1)
        {
            Debug.Log("Index invalid");
            return null;
        }

        if(bag.items[Index] == null)
        {
            Debug.Log("ItemData null");
            return null;
        }
        */
        return bag.items[Index].itemData; ;
    }

}
