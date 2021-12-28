using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    bool pauseState;
    bool cursorVisible;
    bool cursorVisiblePause;
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
            cursorVisible = !cursorVisible;
        

            //player.GetComponent<Rig>();
            //mLook.lockCursor = !mLook.lockCursor;
            //UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorVisiblePause = !cursorVisiblePause;
           
        }



        if (cursorVisible || cursorVisiblePause || Inventory.Instance.isGameOver) { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void pauseExit()
    {
         
        cursorVisiblePause = false;
        pauseState = false;
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
