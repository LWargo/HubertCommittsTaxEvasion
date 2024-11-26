using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class smcode : MonoBehaviour
{
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextLevel(Collider2D other){
        if(other.CompareTag("Player"))
        SceneManager.LoadScene(index);
    }
}
