using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;
    public List<GameObject> positions;
                                
    public AudioClip[] footSounds;
                        
                                                          
    private NavMeshAgent nav;
    public AudioSource sound;
    private Animator anim;
    public int movePlace;
    public bool isEnable = true;
    public GameObject eyes;
    public GameObject eyes1;
    public GameObject eyes2;
    public bool found;
    public float time = 0;
    // Start is called before the first frame update
    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        nav.speed = 1.0f;
        anim.speed = 1.0f;
        
    }
  


    void Search(GameObject eyes)
    {
        RaycastHit hit;
        Ray landingRay = new Ray(eyes.transform.position, eyes.transform.TransformDirection(Vector3.forward) * 10);
        Debug.DrawRay(eyes.transform.position, eyes.transform.TransformDirection(Vector3.forward) * 2, Color.red);
        if (Physics.Raycast(landingRay, out hit, 4))
        {
            Debug.Log("asd");

            if (hit.collider.tag == "Player")
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10,Color.red);
                //Debug.Log("asd1");

                //Interact.SetActive(true);

                //Debug.Log("Thief");
                isEnable = false;
                found = true;
                time += Time.deltaTime;


            }

        }



    }

    // Update is called once per frame
    void Update()
    {


        if(time > 2.5)
        {
            Debug.Log("Game over");
        }

        //Debug.Log(time);


        Search(eyes);
        Search(eyes1);
        Search(eyes2);

        if(found == true)
        {
           
            nav.SetDestination(transform.position);
            StartCoroutine(MoveAIagain());
            
            found = false;
        }

        


















        //Jaber
        anim.SetFloat("velocity", nav.velocity.magnitude);

       
        if (isEnable)
        {
           
            movePlace = Random.Range(0, 3);
            nav.SetDestination(positions[movePlace].transform.position);
            isEnable = false;
            StartCoroutine(MoveAI());

        }
         


        if (nav.speed == 0)
        {
            Idle();
            Debug.Log("Idle AI");
        }
        if(nav.speed >= 0)
        {
            Walk();
            Debug.Log("Walking AI");
        }


        /*  if( Mathf.Abs(positions[movePlace].transform.position.x - gameObject.transform.position.x) < x)
        //if(x)
        {
            StartCoroutine(MoveAI());
        }*/
       

    }

    public void FootStep(int _num)
    {
        sound.clip = footSounds[_num];
        sound.Play();
    }

    IEnumerator MoveAI()
    {
        yield return new WaitForSeconds(Random.Range(20,30));
        isEnable = true;
    }

    IEnumerator MoveAIagain()
    {
        yield return new WaitForSeconds(Random.Range(5,8));
        isEnable = true;
        
        time = 0;
    }

    private void Idle()
    {
        anim.SetFloat("velocity", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {

        anim.SetFloat("velocity", 1.0f, 0.1f, Time.deltaTime);
    }
}
