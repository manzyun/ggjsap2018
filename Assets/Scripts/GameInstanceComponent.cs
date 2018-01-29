using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstanceComponent : MonoBehaviour {

    public int level_index { get; private set; }

    public static GameInstanceComponent Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadLevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadMainScene(int level_index)
    {
        this.level_index = level_index;

        SceneManager.LoadScene("Main");
    }

    public void ReloadMainScene()
    {
        LoadMainScene(level_index);
    }

    public StageClearInfo GetStageClearInfo(int level_index)
    {
        StageClearInfo info;

        info.isClear = PlayerPrefs.GetInt("isClear_" + level_index, 0);
        info.bestScore = PlayerPrefs.GetInt("bestScore_" + level_index, 0);

        return info;
    }

    public void SetStageClearInfo(int level_index, int bestScore)
    {
        PlayerPrefs.SetInt("isClear_" + level_index, 1);

        int oldScore = GetStageClearInfo(level_index).bestScore;

        PlayerPrefs.SetInt("bestScore_" + level_index, Mathf.Max(oldScore, bestScore));
    }
}


public struct StageClearInfo
{
    public int isClear;
    public int bestScore;
}