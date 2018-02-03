using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManagerComponent : MonoBehaviour {
    [SerializeField]
    float before_play_time;
    [SerializeField]
    Spawn enemy_spawner;
    [SerializeField]
    Score score;
    [SerializeField]
    TimeManagerComponent timeManager;
    [SerializeField]
    TextMeshProUGUI middleText;

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
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerState = PlayerMove.PlayerState.BEFORE_PLAY;

        middleText.text = "クリア条件\n" + (int)enemy_spawner.GetTimeLimit() + "秒以内に" + enemy_spawner.GetClearScore() + "点稼げ";
    }

    void SetupPlay()
    {
        state = MainState.Play;
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerState = PlayerMove.PlayerState.PLAY;

        enemy_spawner.SpawnStart();
        timeManager.CountDownStart();

        middleText.text = "";
    }

    public void EndPlay()
    {
        if(score.score >= enemy_spawner.GetClearScore())
        {
            StartCoroutine("SetupClear");
        }
        else
        {
            StartCoroutine("SetupGameOver");
        }
    }

    IEnumerator SetupClear()
    {
        state = MainState.Clear;
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerState = PlayerMove.PlayerState.CLEAR;

        GameInstanceComponent instance = GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>();
        instance.SetStageClearInfo(instance.level_index, score.score);

        middleText.text = "ステージクリア";

        yield return new WaitForSeconds(5.0f);

        instance.LoadLevelSelectScene();
    }

    IEnumerator SetupGameOver()
    {
        state = MainState.GameOver;
        GameObject.FindWithTag("Player").GetComponent<PlayerMove>().playerState = PlayerMove.PlayerState.GAME_OVER;

        GameInstanceComponent instance = GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>();

        middleText.text = "ゲームオーバー";

        yield return new WaitForSeconds(5.0f);

        instance.LoadLevelSelectScene();
    }
}

public enum MainState
{
    BeforePlay,
    Play,
    Clear,
    GameOver
}