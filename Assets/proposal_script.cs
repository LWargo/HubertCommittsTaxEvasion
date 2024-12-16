using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class proposal_script : MonoBehaviour
{
    // Start is called before the first frame update

    public Button yes;
    public Button no; 
    public float trigger;
    public float triggerer;
    void Start()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        yes.onClick.AddListener( () => marriage());
        no.onClick.AddListener( () => rejection());
        
    }

    // Update is called once per frame
    void Update()
    {
        trigger -= Time.deltaTime;
        if( trigger <= triggerer){
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
        }
    
    }
    public void marriage(){
        Debug.Log("hub becomes a hub");
        SceneManager.LoadScene("HappyEverAfter", LoadSceneMode.Single);
    }
    public void rejection(){
        Debug.Log("Sad day to be bob ");
        SceneManager.LoadScene("PlatformPrototype", LoadSceneMode.Single);
    }
}
