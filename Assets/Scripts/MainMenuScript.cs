using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public Button oneBtn;
    // Start is called before the first frame update
    void Start()
    {
        oneBtn.onClick.AddListener( () => goLev1() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void goLev1(){
        SceneManager.LoadScene("HubertDigitalPrototype", LoadSceneMode.Single);
    }
}
