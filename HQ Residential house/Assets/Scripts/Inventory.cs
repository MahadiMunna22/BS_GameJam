using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    float maxWeight = 50f;
    float totalWeight = 0f;
    float totalValue = 0f;
    private void Awake()
    {

      
        Instance = this;
     
    }

    public List<GameObject> items;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Additems(GameObject item)
    {
        if (totalWeight < maxWeight)
        {

            items.Add(item);
            totalWeight += item.GetComponent<ItemsAttributes>().weight;
            totalValue += item.GetComponent<ItemsAttributes>().value;
        }
        else
        {
            Debug.Log("Too heavy");
        }
    }

    public void Removeitems(GameObject item)
    {

    }
}
