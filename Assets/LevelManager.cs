using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour
{
    public int index;
    public GameObject gameOverPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            index++;
            SceneManager.LoadScene(index);
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
