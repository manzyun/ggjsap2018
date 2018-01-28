using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanLaught : MonoBehaviour {

    [SerializeField]
    float LUAGHT_TIME = 5.0f,
          FADE_OUT_TIME = 2.0f;
          
    public float laught { private set; get; }
    bool max_laught_trigger = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            LaughtAdd(0.1f);
        }
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

    }
}
