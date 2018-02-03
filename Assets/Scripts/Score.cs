using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI SCORE_NAMBER;
    public int score { get; private set; }

	// Use this for initialization
	void Start () {
        score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int addPoint)
    {
        score += addPoint;
        SCORE_NAMBER.text = string.Format("{0:D6}", score);
    }

    public void AddScore(float addPoint)
    {
        score += (int)Mathf.Ceil(addPoint);
        SCORE_NAMBER.text = string.Format("{0:D6}", score);
    }
}
