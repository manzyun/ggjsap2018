using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScore : MonoBehaviour {


    [SerializeField]
    float scoreInterval = 1.0f;
    [SerializeField]
    float baseScore = 100f,
          bonaceScore = 1000f;
    private HumanLaught humanLaught;
    private Score score;
    private float timer = 0.0f;

    // Use this for initialization
    void Start () {

        score = GameObject.Find("Scoremaneger").GetComponent<Score>();
        humanLaught = this.GetComponent<HumanLaught>();
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= scoreInterval)
        {
            timer = 0.0f;
            CalcScore();
        }  
	}

    private void CalcScore()
    {
        score.AddScore(humanLaught.laught * baseScore);
    }

    public void BonaceScoreAdd()
    {
        score.AddScore(bonaceScore);
    }

    public void ReSetTimer()
    {
        timer = 0.0f;
        CalcScore();
    }
}
