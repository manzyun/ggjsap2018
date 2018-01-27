using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


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
    }

    public void AddScore(float addPoint)
    {
        score += (int)Mathf.Ceil(addPoint);
    }
}
