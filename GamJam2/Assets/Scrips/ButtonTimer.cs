using UnityEngine;
using UnityEngine.UI;
public class NewMonoBehaviourScript : MonoBehaviour
{
    float Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = 0f;
       
    }


    // Update is called once per frame
    void Update()
    {if (Timer <= 2f)
        {
            Timer += Time.deltaTime;
            GetComponent<Button>().interactable = false;
        }
        else
        {
        GetComponent<Button>().interactable = true;
    }    
    }
}

