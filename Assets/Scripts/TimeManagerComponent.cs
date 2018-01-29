using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManagerComponent : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    Spawn spawn;
    [SerializeField]
    MainManagerComponent mainManager;
    float time;
    bool countDownTrigger = false;
	// Use this for initialization
	void Start () {
        time = spawn.GetTimeLimit();
	}
	
	// Update is called once per frame
	void Update () {
        if(countDownTrigger && time > 0)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                time = 0.0f;
                mainManager.EndPlay();
            }
        }

		int int_time = (int)Mathf.Ceil(time);
        timeText.text = int_time / 60 + ":" + string.Format("{0:D2}", int_time % 60);
    }

    public void CountDownStart()
    {
        countDownTrigger = true;
    }
}
