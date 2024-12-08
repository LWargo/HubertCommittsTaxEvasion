using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GHCutManager : MonoBehaviour
{

    private Scene scene;
    public float triggerTime;
    public int index;
    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        triggerTime -= Time.deltaTime;
        if(triggerTime <= 0 && scene.name == "GetHomeCutScene"){
            SceneManager.LoadScene("PlatformPrototype", LoadSceneMode.Single);
        }
        if(triggerTime <= 0 && scene.name == "IntroCutScene"){
          //  index = 0;
            SceneManager.LoadScene("IntroPart2", LoadSceneMode.Single);
           // SceneManager.LoadScene(index);
        }
        if(triggerTime <= 0 && scene.name == "IntroPart2"){
            index = 0;
            //SceneManager.LoadScene("PlatformPrototype", LoadSceneMode.Single);
            SceneManager.LoadScene(index);
        }
        if(triggerTime <= 0 && scene.name == "CallFromBob"){
            index = 1;
            //SceneManager.LoadScene("PlatformPrototype", LoadSceneMode.Single);
            SceneManager.LoadScene(index);
        }
    }
}
