using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScore : MonoBehaviour {
    [SerializeField]
    public float baseScore = 10f,
                bonusScore = 100f;
    private Score score;
    private float timer = 0.0f;

    // Use this for initialization
    void Start () {
        score = GameObject.Find("ScoreManager").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void AddScore(float laught)
    {
        score.AddScore(CalcScore(laught));
    }

    public void AddBonusScore()
    {
        score.AddScore(bonusScore);
    }

    float CalcScore(float laught)
    {
        return laught * baseScore;
    }
}
