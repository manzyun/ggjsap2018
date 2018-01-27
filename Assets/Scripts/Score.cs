using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text SCORE_NAMBER;
    public int score { get; private set; }

	// Use this for initialization
	void Start () {

        SCORE_NAMBER = GameObject.Find("ScoreNamber").GetComponent<Text>();
        score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int addPoint)
    {
        score += addPoint;
        SCORE_NAMBER.text = score.ToString();
    }

    public void AddScore(float addPoint)
    {
        score += (int)Mathf.Ceil(addPoint);
        SCORE_NAMBER.text = score.ToString();
    }
}
