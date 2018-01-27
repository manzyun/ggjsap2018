using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLaught : MonoBehaviour {

    [SerializeField]
    float LUAGHT_TIME = 5.0f,
          FADE_OUT_TIME = 2.0f;
          
    public float laught { private set; get; }

    HumanScore score_com;

	// Use this for initialization
	void Start () {
        score_com = GetComponent<HumanScore>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LaughtAdd(float AddPoint)
    {
        if(laught == 0.0f)
        {
            laught += AddPoint;
            score_com.ReSetTimer();
        }
        else
        {

            laught += AddPoint;

            if (laught > 1.0f)
            {
                laught = 1.0f;
                StartCoroutine("LaughtMax");
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
        GetComponent<HumanScore>().BonaceScoreAdd();
    }
}
