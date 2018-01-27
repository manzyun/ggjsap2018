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
}
