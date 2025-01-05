using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SlotType slotType;
    public ItemUI itemUI;

    public void UpdateItem()
    {
        switch(slotType)
        {
            case SlotType.ACTION:
                itemUI.bag = InventoryManager.Instance.actionData;
                break;
            case SlotType.WEAPON:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.CONTAINER:
                itemUI.bag = InventoryManager.Instance.chestData;
                break;
            case SlotType.ARMOR_HEAD:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_EYE:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_BODY:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_LEG:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
            case SlotType.ARMOR_FEET:
                itemUI.bag = InventoryManager.Instance.equipmentData;
                break;
        }
        var item = itemUI.bag.items[itemUI.Index];
    
        itemUI.UpdateItemUI(item.itemData, item.amount);
    }

    #region DoubleClick
    public void OnPointerClick(PointerEventData eventData)
    {
       // Double Click
        if(eventData.clickCount % 2 == 0)
        {
                if(itemUI.GetItem() == null)
                {
                    return;
                }

                // Sell and Buy
                if(InventoryManager.Instance.isSelling)
                {
                    if (slotType == SlotType.CONTAINER )
                    {
                        SellItem();
                    } 
                    //else if (slotType == SlotType.SOLD)
                    //{
                        //BuyBackItem();

                    //}
                }
                // Use
                else
                {
                    UseItem();
                }
        }
    }

    public void UseItem() {
        if (itemUI.bag.items[itemUI.Index].amount > 0)
        {
            ItemType _type = itemUI.GetItem().itemType;
            int _id = itemUI.GetItem().id;
            /*
            switch (_type)
            {
                case ItemType.POTION:
                    
                    if (!itemUI.isValid) return;

                    if (ItemManager.Instance == null) return;

                    itemUI.ResetCd();
                    if (slotType == SlotType.BAG)
                        InventoryManager.Instance.inventoryData.RemoveItem(itemUI.GetItem(), 1);
                    else if (slotType == SlotType.ACTION)
                        InventoryManager.Instance.actionData.RemoveItem(itemUI.GetItem(), 1);
                    switch (_id)
                    {
                        case 1://big mana potion
                            break;
                        case 2://big speed potion
                            ItemManager.Instance.OnSpeedPotion();
                            break;
                        case 3://big damage potion
                            ItemManager.Instance.OnDamagePotion();
                            break;
                        case 4://big health potion
                            ItemManager.Instance.OnHealthPotion(0.25f);
                            break;
                        case 5://big defense potion
                            ItemManager.Instance.OnDefensePotion();
                            break;
                        case 6://small mana potion
                            break;
                        case 7://small speed potion
                            ItemManager.Instance.OnSpeedPotion();
                            break;
                        case 8://small damage potion
                            ItemManager.Instance.OnDamagePotion();
                            break;
                        case 9://small health potion
                            ItemManager.Instance.OnHealthPotion(0.1f);
                            break;
                        case 10://small defense potion
                            ItemManager.Instance.OnDefensePotion();
                            break;
                        default:
                            break;
                            
                    }

                    break;
                case ItemType.ARTIFACT:
                    
                    if (!itemUI.isValid) return;

                    if (ItemManager.Instance == null) return;

                    itemUI.ResetCd();

                    switch (_id)
                    {

                        default:
                            break;
                    }
                    break;
                case ItemType.FOOD:
                    InventoryManager.Instance.inventoryData.RemoveItem(itemUI.GetItem(), 1);
                    break;
                default:
                    break;
            }
            */

        }
        UpdateItem();
    }

    public void SellItem()
    {
        if(itemUI.GetItem().CanBeSold== true && itemUI.bag.items[itemUI.Index].amount > 0) 
        {
                Debug.Log("sell");
                var itemPrice = itemUI.GetItem().soldPrice;
                //GameManager.Instance.playerStats.playerData.coins += itemPrice;
            
                InventoryManager.Instance.soldData.AddItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.soldContainerUI.RefreshUI();

                InventoryManager.Instance.inventoryData.RemoveItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.inventoryUI.RefreshUI();

        }
        UpdateItem();
    }

    public void BuyBackItem()
    {
        if (itemUI.GetItem().CanBeSold == true && itemUI.bag.items[itemUI.Index].amount > 0)
        {
                var itemPrice = itemUI.GetItem().soldPrice;
                //if(GameManager.Instance.playerStats.playerData.coins >= itemPrice )
                 //   GameManager.Instance.playerStats.playerData.coins -= itemPrice;

                InventoryManager.Instance.inventoryData.AddItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.inventoryUI.RefreshUI();

                InventoryManager.Instance.soldData.RemoveItem(itemUI.GetItem(), 1);
                InventoryManager.Instance.soldContainerUI.RefreshUI();
        }
    }

    #endregion

    #region ToopTip
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(itemUI.GetItem())
        {
            InventoryManager.Instance.tooltip.SetupTooltip(itemUI.GetItem());
            InventoryManager.Instance.tooltip.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        if(InventoryManager.Instance != null)
        {
        InventoryManager.Instance.tooltip.gameObject.SetActive(false);
        }

    }
    #endregion

}


