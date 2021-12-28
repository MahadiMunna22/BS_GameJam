using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Detector : MonoBehaviour
{
   
    public GameObject Interactobj;
    public GameObject Interacthuman;
    public GameObject gameOverScreen;

    public GameObject panel; 
    public LayerMask occlusionLayers;



    bool isopen;

    int index = 0;
    GameObject interceptedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    // Update is called once per frame
    void Update()
    {

        if(Inventory.Instance.isGameOver)
        {
            Inventory.Instance.GameOver();
            gameOverScreen.SetActive(true);
        }
        //if (Interact == null) return;
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 3);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        if (Physics.Raycast(landingRay, out hit, 3))
        {
            //Debug.Log("asd");


          


           if (hit.collider.tag == "Pickable" )
                {

                Debug.Log("Interactive");
                Interactobj.SetActive(true);
                    interceptedObj = hit.transform.gameObject;
                    interceptedObj.GetComponent<Outline>().enabled = true;

                    if (Input.GetKeyDown(KeyCode.Q) )
                    {


                        Inventory.Instance.Additems(interceptedObj);

                    if(Inventory.Instance.canBepicked)
                        interceptedObj.SetActive(false);


                       // Debug.Log(Inventory.Instance.totalWeight );


                    }



                }

               

                else
                {
                 
                    Interactobj.SetActive(false);
                }
            }



        RaycastHit hithuman;
        Ray landingRayhuman = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 3);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        if (Physics.Raycast(landingRay, out hithuman, 10))
        {
            //Debug.Log("asd");





           

            if (hithuman.collider.tag == "PoorGuy")
            {


                Interacthuman.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Inventory.Instance.setTarget();
                    panel.SetActive(true);


                    if (Inventory.Instance.totalValue >= 2000)
                    {
                        panel.GetComponent<DialogManager>().stealingDone = true;
                    }

                }




            }

            else
            {
                Debug.Log("not disappearing");
                panel.SetActive(false);
                Interacthuman.SetActive(false);
            }
        }

    }
        
    void takeobject()
    {

    }


     
}
