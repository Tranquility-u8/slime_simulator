using UnityEngine;


public class ItemPickUp : MonoBehaviour
{
    public ItemData_SO itemData;
    [SerializeField]private string interactText="Pick up the Item";


    #region IInteractable
    public string GetInteractText()
    {
        return interactText;
    }

    public KeyCode GetKeyCode()
    {
        return KeyCode.E;
    }

    public Transform GetTransform()
    {
        return transform;
    }
    public void OnInteract()
    {

        InventoryManager.Instance.inventoryData.AddItem(itemData, itemData.itemAmount);
        InventoryManager.Instance.inventoryUI.RefreshUI();
        
        Destroy(gameObject);
    }

    #endregion





}
