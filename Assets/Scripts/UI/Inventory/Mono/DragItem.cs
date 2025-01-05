using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemUI))]
public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ItemUI currentItemUI;
    private SlotHolder currentHolder;
    private SlotHolder targetHolder;
    private ItemUI targetItemUI;

    void Awake()
    {
        currentItemUI = GetComponent<ItemUI>();
        currentHolder = GetComponentInParent<SlotHolder>();
    }

    #region Drag Interface

    public void OnBeginDrag(PointerEventData eventData)
    {
        InventoryManager.Instance.currentDrag = new InventoryManager.DragData();
        InventoryManager.Instance.currentDrag.originalHolder = GetComponentInParent<SlotHolder>();
        InventoryManager.Instance.currentDrag.originalParent = (RectTransform)transform.parent;

        transform.SetParent(InventoryManager.Instance.dragCanvas.transform, true);

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (InventoryManager.Instance.CheckInAll(eventData.position))
            {
                if (eventData.pointerEnter.gameObject.GetComponent<SlotHolder>())
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponent<SlotHolder>();
                    targetItemUI = targetHolder.itemUI;

                }

                else
                {
                    targetHolder = eventData.pointerEnter.gameObject.GetComponentInParent<SlotHolder>();
                    if (targetHolder == null)
                        goto ONEND;
                    targetItemUI = targetHolder.itemUI;
                }
                
                if (targetHolder != InventoryManager.Instance.currentDrag.originalHolder)
                    switch (targetHolder.slotType)
                    {
                        case SlotType.CONTAINER:
                            SwapController();
                            break;
                        case SlotType.WEAPON:
                            SwapController(ItemType.WEAPON);
                            break;
                        case SlotType.ACTION:
                            SwapController();
                            break;
                        case SlotType.ARMOR_HEAD:
                            SwapController(ItemType.ARMOR_HEAD);
                            break;
                        case SlotType.ARMOR_EYE:
                            SwapController(ItemType.ARMOR_EYE);
                            break;
                        case SlotType.ARMOR_BODY:
                            SwapController(ItemType.ARMOR_BODY);
                            break;
                        case SlotType.ARMOR_LEG:
                            SwapController(ItemType.ARMOR_LEG);
                            break;
                        case SlotType.ARMOR_FEET:
                            SwapController(ItemType.ARMOR_FEET);
                            break;
                    }
                
                currentHolder.UpdateItem();
                targetHolder.UpdateItem();
            }
        }
    
        ONEND:
        transform.SetParent(InventoryManager.Instance.currentDrag.originalParent);

        RectTransform t = transform as RectTransform;
        t.offsetMax = -Vector2.one * 1f;
        t.offsetMin = -Vector2.one * 1f;

        UIManager.Instance.updateStatus();
    }

    private void SwapController(ItemType targetItemType)
    {
        /*
        if (currentHolder.slotType == targetHolder.slotType || currentItemUI.GetItem().itemType == targetItemType)
        {
            SwapItem();
        }
        */
        if (currentItemUI.GetItem().itemType == targetItemType)
        {
            SwapItem();
        }
    }

    private void SwapController()
    {
        /*
        if (currentHolder.slotType == targetHolder.slotType || targetItemUI.GetItem() == null || currentItemUI.GetItem().itemType == targetItemUI.GetItem().itemType)
        {
            SwapItem();
        }
        */
        SwapItem();

    }
    #endregion


    public void SwapItem()
    {

        var targetItem = targetHolder.itemUI.bag.items[targetHolder.itemUI.Index];
        var tempItem = currentHolder.itemUI.bag.items[currentHolder.itemUI.Index];

        bool isSameItem = tempItem.itemData == targetItem.itemData; //��Ʒ��ͬ��

        if (isSameItem && targetItem.itemData.stackable) //ͬ��Ʒ and �ɶѵ�
        {
            targetItem.amount += tempItem.amount;
            tempItem.itemData = null;
            tempItem.amount = 0;
        }
        else
        {
            currentHolder.itemUI.bag.items[currentHolder.itemUI.Index] = targetItem;
            targetHolder.itemUI.bag.items[targetHolder.itemUI.Index] = tempItem;

        }

    }

}
