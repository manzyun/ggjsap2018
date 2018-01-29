using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayAnime : MonoBehaviour
{
    HumanDetectAnimeState detect;
    HumanAnimeState cur_anime_state;
    float timer = 0.0f;

    HumanGender gender;

    [SerializeField]
    Sprite[] maleBodySprites, femaleBodySprites;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float animeDuration;

    [SerializeField]
    TextAsset maleMocFile, femaleMocFile;
    [SerializeField]
    Texture2D[] maleTextureFiles, femaleTextureFiles;
    [SerializeField]
    SimpleModel model;

    // Use this for initialization
    void Start()
    {
        detect = GetComponent<HumanDetectAnimeState>();
        cur_anime_state = detect.state;

        gender = GetComponent<HumanGender>();

        SetLive2D();
    }

    void SetLive2D()
    {
        if(gender.gender == Gender.male)
        {
            model.mocFile = maleMocFile;
            model.textureFiles = maleTextureFiles;
        }
        else
        {
            model.mocFile = femaleMocFile;
            model.textureFiles = femaleTextureFiles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(detect.state != cur_anime_state)
        {
            cur_anime_state = detect.state;
            timer = 0.0f;

            if(cur_anime_state == HumanAnimeState.Stand)
            {
                spriteRenderer.sprite = GetProperSprite(0);
                spriteRenderer.flipX = false;
            }
            else if(cur_anime_state == HumanAnimeState.Left)
            {
                spriteRenderer.sprite = GetProperSprite(1);
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.sprite = GetProperSprite(1);
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            if(cur_anime_state != HumanAnimeState.Stand)
            {
                timer += Time.deltaTime;
                if(0 <= timer && timer < animeDuration * 0.5f)
                {
                    spriteRenderer.sprite = GetProperSprite(1);
                }
                else if(animeDuration * 0.5f <= timer && timer < animeDuration)
                {
                    spriteRenderer.sprite = GetProperSprite(2);
                }
                else
                {
                    timer = 0.0f;
                }
            }
        }
    }

    Sprite GetProperSprite(int index)
    {
        if(gender.gender == Gender.male)
        {
            return maleBodySprites[index];
        }
        else
        {
            return femaleBodySprites[index];
        }
    }
}
