using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;


    float maxWeight = 50f;
    float totalWeight = 0f;
    float totalValue = 0f;
    private void Awake()
    {

      
        Instance = this;
       

    }

    public List<GameObject> items;
    
   

    public void Additems(GameObject item)
    {
        if (totalWeight < maxWeight)
        {

            items.Add(item);
            totalWeight += item.GetComponent<ItemsAttributes>().weight;
            totalValue += item.GetComponent<ItemsAttributes>().value;
            if (OnItemChangedCallback != null)
            { 
                OnItemChangedCallback.Invoke(); 
            }
        }
        else
        {
            Debug.Log("Too heavy");
        }
    }

    public void Removeitems(GameObject item)
    {
       

        items.Remove(item);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
