using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour
{
    public int index;
    public string namee;
  //  public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        namee = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
       // Debug.Log("hit trigger");
        if(other.CompareTag("Player") && (index != 4)){ // aka if you're on levels 1-4
            index++;
            SceneManager.LoadScene(index);
        }
        if(other.CompareTag("Player") && (index == 4)){ // if I'm on level 5
            Debug.Log("switching out of level 5");
            SceneManager.LoadScene("GetHomeCutScene", LoadSceneMode.Single);
        }
        
    }

}
