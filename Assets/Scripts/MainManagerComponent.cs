using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerComponent : MonoBehaviour {
    [SerializeField]
    float before_play_time;
    [SerializeField]
    Spawn enemy_spawner;
    [SerializeField]
    Score score;
    [SerializeField]
    TimeManagerComponent timeManager;

    public MainState state { get; private set; }
	// Use this for initialization
	void Start () {
        state = MainState.BeforePlay;
        StartCoroutine("PlayCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator PlayCoroutine()
    {
        SetupBeforePlay();
        yield return new WaitForSeconds(before_play_time);

        SetupPlay();
    }

    void SetupBeforePlay()
    {

    }

    void SetupPlay()
    {
        state = MainState.Play;
        enemy_spawner.SpawnStart();
        timeManager.CountDownStart();
    }

    public void EndPlay()
    {
        if(score.score >= enemy_spawner.GetClearScore())
        {
            SetupClear();
        }
        else
        {
            SetupGameOver();
        }
    }

    void SetupClear()
    {
        state = MainState.Clear;
    }

    void SetupGameOver()
    {
        state = MainState.GameOver;
    }
}

public enum MainState
{
    BeforePlay,
    Play,
    Clear,
    GameOver
}