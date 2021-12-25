using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
   
  //  [SerializeField] GameObject Interact;

    GameObject interceptedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 10);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        if (Physics.Raycast(landingRay, out hit, 1000))
        {
            Debug.Log("asd");

            if (hit.collider.tag == "Pickable")
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10,Color.red);
                Debug.Log("asd1");

                //Interact.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log(hit.transform.gameObject.name);
                   interceptedObj = hit.transform.gameObject;
                  
                   Inventory.Instance.Additems(interceptedObj); 
                   interceptedObj.SetActive(false);
                   //Debug.Log(Inventory.Instance.items[0].GetComponent<ItemsAttributes>().weight);
                        

                }

            }
            else
            {
                //Interact.SetActive(false);
            }
        }
        else
        {
            //Interact.SetActive(false);
        }
    }
}
