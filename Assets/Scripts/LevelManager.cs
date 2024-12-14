using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;



public class LevelManager : MonoBehaviour
{
    public int index;
    public string sceneName;
    public HubertBehavior hb;
  //  public GameObject door;
    public GameObject gameOverPanel;
    public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        sceneName = SceneManager.GetActiveScene().name;
        hb = FindObjectOfType<HubertBehavior>();

        audioManager = FindObjectOfType<AudioManager>();
        if(sceneName.Equals("MainMenu")) {
            audioManager.Stop();
            audioManager.Play("MainMenuMusic");
        } else if(sceneName.Equals("Maze1Final")) {
            audioManager.Stop();
            audioManager.Play("LevelMusic1");
        } else if(sceneName.Equals("Maze2Final")) {
            audioManager.Stop();
            audioManager.Play("LevelMusic2");
        } else if(sceneName.Equals("Maze5Final")) {
            audioManager.Stop();
            audioManager.Play("LevelMusic3");
        } else if(sceneName.Equals("PlatformPrototype")) {
            audioManager.Stop();
            audioManager.Play("BossMusic");
        } else if(sceneName.Equals("VictoryCredits")) {
            audioManager.Stop();
            audioManager.Play("VictoryMusic");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            ReloadCurrentScene();
        }
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
        // Debug.Log("RELOAD");
        SceneManager.LoadScene(index);
    }

    public void LoadMainMenu() {
        // Debug.Log("MAIN MENU");
        SceneManager.LoadScene(6);
    }

    public void LoadVictory() {
        SceneManager.LoadScene(13);
    }
}
