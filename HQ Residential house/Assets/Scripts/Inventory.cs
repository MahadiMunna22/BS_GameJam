using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public GameObject heavy;
    public float maxWeight = 0f;
    public float totalWeight = 0f;
    public float totalValue = 0f;
    public bool canBepicked =true;
     
    public TMPro.TextMeshProUGUI valueText;
    public TMPro.TextMeshProUGUI weightText;
    public GameObject targetText; 
    public bool isPaused = false;
    public bool isGameOver = false;
    public bool moveEnabled;

    private void Awake()
    {

      
        Instance = this;
       

    }

    public List<GameObject> items;

    public void GameOver()
    {
        //Time.timeScale = 0.0f;
    }

    public void Additems(GameObject item)
    {
        if (totalWeight + item.GetComponent<ItemsAttributes>().weight < 100)
        {
            canBepicked = true;
            items.Add(item);
            totalWeight += item.GetComponent<ItemsAttributes>().weight;
            totalValue += item.GetComponent<ItemsAttributes>().value;

            weightText.text = totalWeight + " Kg";
            valueText.text = totalValue + " $";
            Debug.Log(totalWeight);
            if (OnItemChangedCallback != null)
            { 
                OnItemChangedCallback.Invoke(); 
            }
        }
        else  
        {
            canBepicked = false;
            Debug.Log(totalWeight + "Exceeded");
            heavy.SetActive(true);
           
            StartCoroutine(ShowHeavy());

          
 
        }
    }


    public void setTarget()
    {
        targetText.SetActive(true);
    }

    IEnumerator ShowHeavy()
    {
        yield return new WaitForSeconds(5);
        heavy.SetActive(false);

    }


    public void Removeitems(GameObject item)
    {

        totalWeight -= item.GetComponent<ItemsAttributes>().weight;
        totalValue -= item.GetComponent<ItemsAttributes>().value;
        items.Remove(item);

        weightText.text = totalWeight + " Kg";
        valueText.text = totalValue + " $";

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();

        }
    }
}
