using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using  UnityStandardAssets.Characters.FirstPerson;

public class InventoryUi : MonoBehaviour
{
    public Transform itemsParent;

   // public MouseLook mLook;

    InventorySlot[] slots;
    Inventory inventory;

    public GameObject bag;
    public GameObject player;

    bool state;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChangedCallback += UpdateUI;
        

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            state = !state;
            bag.SetActive(state);
            //player.GetComponent<Rig>();
            //mLook.lockCursor = !mLook.lockCursor;
            //UpdateUI();
        }
    }

    void UpdateUI()
    {
        Debug.Log("Update UI");
        for(int i =0; i<slots.Length;i++)
        {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i].GetComponent<ItemsAttributes>(), inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
