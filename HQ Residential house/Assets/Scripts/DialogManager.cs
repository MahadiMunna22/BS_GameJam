using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
 

 

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] dialogs = new string[]{"Hello brother, please help me", "That man living in that house took away my properties", "Now I have nothing and I am homeless", "I heard you help the homeless poor people", "So I called you", "Please help me"};

    public string[] endDialogs = { "You are a hero", "That person deserved it and I can also start a new life from here", "Thank you so much" };

    public TMPro.TextMeshProUGUI text; 
    public Button LoadNext;
    private int dialogNum = 0;
    private int endDialogNum = 0;
    public bool stealingDone;
    public GameObject dialogPanel;
    public GameObject initaialBorder;
    
    

    

    private void Start()
    {
        dialogNum = 0;
        endDialogNum = 0;
        if (stealingDone)
        {
            text.text = endDialogs[endDialogNum];
        }
        else
        {   
            text.text = dialogs[dialogNum];
         
        }

        Button btn = LoadNext.GetComponent<Button>();
        btn.onClick.AddListener(LoadNextDialog);
    }
    private void Update()
    {
        
        
    }

    public void LoadNextDialog()
    {
        if (stealingDone)
        {
            Debug.Log("Stealing Done");
            if (endDialogNum < endDialogs.Length - 1)
            {
                endDialogNum += 1;
                text.text = endDialogs[endDialogNum];
            }
            else
            {
                dialogPanel.SetActive(false);
                endDialogNum = 0;
            }
        }
        else
        {
            Debug.Log("Stealing Not Done");
            if (dialogNum < dialogs.Length - 1)
            {
                dialogNum += 1;
                text.text = dialogs[dialogNum];
            }
            else
            {
                initaialBorder.SetActive(false);    
                dialogPanel.SetActive(false);
                dialogNum = 0;
            }
        }
        
    }
}
