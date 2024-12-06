using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public Button oneBtn;
    public Button tut;
    // Start is called before the first frame update
    void Start()
    {
        oneBtn.onClick.AddListener( () => goLev1() );
        tut.onClick.AddListener( () => goTut());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void goLev1(){
        SceneManager.LoadScene("Maze1Final", LoadSceneMode.Single);
    }
    void goTut(){
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
