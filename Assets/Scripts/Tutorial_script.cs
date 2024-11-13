using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class Tutorial_script : MonoBehaviour
{
    public Button next_btn;
    public TMP_Text tutorial;
    public int step_count;
    public GameObject iceCream;
    public GameObject walls;
    public GameObject enemy;
    public Button mm;
    // Start is called before the first frame update
    void Start()
    {
        step_count = 0;
        tutorial.text = "Welcome to the tutorial for Hubert Committs Tax Evasion!";
        next_btn.onClick.AddListener( () => nextStep() );
        mm.onClick.AddListener( () => go_menu());
        iceCream.SetActive(false);
        walls.SetActive(false);
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void go_menu(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    void nextStep(){
        if(step_count == 0){
            tutorial.text = "Use the arrow keys to move Hubert around the screen";
            step_count++;
            return;
        }
        if(step_count == 1){
            tutorial.text = "Hubert owns his own ice cream truck, and this is an ice cream he sells. Navigate him around the screen to collect an ice cream!";
            step_count++;
            iceCream.SetActive(true);
            return;
        }
        if(step_count == 2){
            tutorial.text = "Hubert is trying to go home, but he is stuck in a maze! Help him manuever around the maze walls";
            step_count++;
            walls.SetActive(true);
            return;
        }
        if(step_count == 3){
            tutorial.text = "With his ice cream business, Hubert committed tax evasion this year! The IRS is out to get him! Help Hubert stay away from the IRS agent!";
            step_count++;
            enemy.SetActive(true);
            return;
        }
        if(step_count == 4){
            tutorial.text = "Sometimes, there will be powerups laying around to collect...";
            step_count++;
            return;
        }
    }
}
