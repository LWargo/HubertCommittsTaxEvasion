using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BossFightHandler : MonoBehaviour
{
    public TMP_Text introText;
    public GameObject victoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Intro() {
        yield return new WaitForSeconds(3);
        introText.gameObject.SetActive(false);
    }

    public void bossDefeated() {
        victoryPanel.gameObject.SetActive(true);
    }
}
