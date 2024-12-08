using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convo_script : MonoBehaviour
{
    public GameObject speech1;
    public GameObject speech2;
    public float triggerTime;
    public float firstTalk;
    public float secondTalk;
    public float totalTalk;
    public float finishTime;
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        speech1.gameObject.SetActive(false);
        speech2.gameObject.SetActive(false);
        cloud.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        triggerTime -= Time.deltaTime;
        if(triggerTime <= totalTalk && triggerTime >= firstTalk ){
            cloud.gameObject.SetActive(true);
            speech1.gameObject.SetActive(true);
        }
        if(triggerTime <= firstTalk){
            speech1.gameObject.SetActive(false);
            speech2.gameObject.SetActive(true);
        }
        if(triggerTime <= finishTime){
            speech1.gameObject.SetActive(false);
            speech2.gameObject.SetActive(false);
            cloud.gameObject.SetActive(false);
        }
    }
}
