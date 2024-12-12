using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;



public class LevelManager : MonoBehaviour
{
    public int index;
    public string namee;
    public HubertBehavior hb;
  //  public GameObject door;
    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        namee = SceneManager.GetActiveScene().name;
        hb = FindObjectOfType<HubertBehavior>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
       // Debug.Log("hit trigger");
        if(other.CompareTag("Player") && (index != 4)){ // aka if you're on levels 1-4
            if((index == 0 ) && (hb.icc >= 2)){ //if you're on level 1 and you hit the minimum number of required ice creams
                SceneManager.LoadScene("CallFromBob", LoadSceneMode.Single);
            }
            if((index == 2 ) && (hb.icc >= 2)){ //if you're on level 2 and you hit the minimum number of required ice creams
                SceneManager.LoadScene("DinnerWithBob", LoadSceneMode.Single);
            }
            else{
                index++;
                SceneManager.LoadScene(index);
            }
        } 
        if(other.CompareTag("Player") && (index == 4)){ // if I'm on level 5
            Debug.Log("switching out of level 5");
            SceneManager.LoadScene("GetHomeCutScene", LoadSceneMode.Single);
        }
        
    }

    public void gameOver() {
        gameOverPanel.SetActive(true);
    }

    public void ReloadCurrentScene() {
        SceneManager.LoadScene(index);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(6);
    }
}
