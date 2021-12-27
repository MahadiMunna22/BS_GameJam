using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Detector : MonoBehaviour
{
   
    [SerializeField] GameObject Interact;
    public GameObject panel; 
    public List<GameObject> dialogues;
    public List<string> dialogues1;

    int index = 0;
    GameObject interceptedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Interact == null) return;
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 10);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        if (Physics.Raycast(landingRay, out hit, 1000))
        {
            //Debug.Log("asd");

            if (hit.collider.tag == "Pickable")
            {
                 

                Interact.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Q))
                {
                     
                   interceptedObj = hit.transform.gameObject;
                  
                   Inventory.Instance.Additems(interceptedObj); 
                   interceptedObj.SetActive(false);
                    //Debug.Log(Inventory.Instance.items[0].GetComponent<ItemsAttributes>().weight);
                   

                }



            }

            else if (hit.collider.tag == "PoorGuy")
            {
                 

                Interact.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                   
                    panel.SetActive(true);
                    dialogues[index].SetActive(true);
                    

                    if(Inventory.Instance.totalValue>0)
                    {
                        dialogues[0].SetActive(false);
                        index = 1;
                        dialogues[index].SetActive(true);
                    }
                 /*   panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=dialogues1[0];

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogues1[1];
                    } 

                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogues1[2];
                    }*/
                }

                


            }

            else
            {
                dialogues[index].SetActive(false);
                panel.SetActive(false);
                Interact.SetActive(false);
            }
        }
        
    }


     
}
