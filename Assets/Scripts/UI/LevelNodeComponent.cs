using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNodeComponent : MonoBehaviour
{
    [SerializeField]
    Button background_button;
    [SerializeField]
    Image lock_image;
    [SerializeField]
    Text level_text,
    score_num_text;

    [SerializeField]
    Sprite lock_sprite, unlock_sprite;

    bool is_lock;
    int level_index;
    int bestscore;

    public void SetupUI(int level_index)
    {
        this.level_index = level_index;

        if (level_index == 0)
        {
            this.is_lock = false;
            this.bestscore = GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>().GetStageClearInfo(level_index).bestScore;
        }
        else
        {
            this.is_lock = GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>().GetStageClearInfo(level_index - 1).isClear == 0 ? true : false;
            this.bestscore = GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>().GetStageClearInfo(level_index).bestScore;
        }

        if (is_lock)
        {
            lock_image.sprite = lock_sprite;
            background_button.GetComponent<Button>().interactable = false;
        }
        else
        {
            lock_image.sprite = unlock_sprite;
            background_button.GetComponent<Button>().interactable = true;
        }

        level_text.text = "Level" + string.Format("{0:D2}", level_index + 1);

        score_num_text.text = string.Format("{0:D6}", bestscore);
    }

    public void OnButtonClick()
    {
        GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>().LoadMainScene(level_index);
    }
}
