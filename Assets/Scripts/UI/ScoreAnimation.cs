using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAnimation : MonoBehaviour {
    TextMeshProUGUI text;
    float timer;
	public void StartAnimation(int score)
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = score.ToString();
    }

    private void Update()
    {
        if(text != null)
        {
            text.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
            timer += Time.deltaTime * 10.0f;
            transform.localScale = new Vector3(1, 1, 1) + new Vector3(1, 1, 1) * Mathf.Abs(Mathf.Sin(timer));
        }
    }
}
