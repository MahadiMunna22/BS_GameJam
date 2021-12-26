using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Button removeButton;

    ItemsAttributes item;

    GameObject stolenObject;
    public void AddItem(ItemsAttributes newItem, GameObject stolen)
    {
        item = newItem;
        stolenObject = stolen;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

     public void ClearSlot()
    {
        //Debug.Log("XXX");
        removeButton.interactable = false;
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //OnRemoveButton();



    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Removeitems(stolenObject);
        //ClearSlot();
    }

   


}
