using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public Button oneBtn;
    public Button twoBtn;
    public Button threeBtn;
    public Button tut;
    // Start is called before the first frame update
    void Start()
    {
        oneBtn.onClick.AddListener( () => goLev1() );
        twoBtn.onClick.AddListener( () => goLev2() );
        threeBtn.onClick.AddListener( () => goLev3() );
        tut.onClick.AddListener( () => goTut());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void goLev1(){
        SceneManager.LoadScene("Maze1Final", LoadSceneMode.Single);
    }

    void goLev2(){
        SceneManager.LoadScene("Maze2Final", LoadSceneMode.Single);
    }
    void goLev3(){
        SceneManager.LoadScene("Maze3Final", LoadSceneMode.Single);
    }
    void goTut(){
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
