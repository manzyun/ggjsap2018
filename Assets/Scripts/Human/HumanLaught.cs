﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLaught : MonoBehaviour {

    [SerializeField]
    float LUAGHT_TIME = 5.0f,
          FADE_OUT_TIME = 2.0f;

    [SerializeField]
    AudioSource hitAudioSource, successAudioSource;
    [SerializeField]
    ScoreAnimation scoreAnimation;
          
    public float laught { private set; get; }
    bool max_laught_trigger = false;

	// Use this for initialization
	void Start () {
		
	}

    public void LaughtAdd(float AddPoint)
    {
        if (max_laught_trigger == false)
        {
            laught += AddPoint;

            if (laught > 1.0f)
            {
                max_laught_trigger = true;
                laught = 1.0f;
                StartCoroutine("LaughtMax");
            }
            else
            {
                hitAudioSource.Play();
                GetComponent<HumanScore>().AddScore(laught);
                GetComponent<HumanMove>().GoRandomPosition();
            }
        }
    }

    private IEnumerator LaughtMax()
    {
        //笑う処理
        OnLaughtValueMax();

        yield return new WaitForSeconds(LUAGHT_TIME);

        //消える処理
        yield return new WaitForSeconds(FADE_OUT_TIME);

        Destroy(this.gameObject);

    }

    private void OnLaughtValueMax()
    {
        successAudioSource.Play();
        GetComponent<HumanScore>().AddBonusScore();
        scoreAnimation.StartAnimation((int)GetComponent<HumanScore>().bonusScore);
    }
}
