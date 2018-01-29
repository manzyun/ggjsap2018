using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerState
    {
        BEFORE_PLAY,
        PLAY,
        CLEAR,
        GAME_OVER
    }
    public PlayerState playerState = PlayerState.PLAY;

    private Rigidbody rb;

    /// <summary>
    /// 移動速度
    /// </summary>
    [Header("移動速度")]
    [SerializeField]
    private float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        switch (playerState)
        {
            case PlayerState.PLAY:
                // 入力を取得
                float x_input = Input.GetAxis("Horizontal") * speed;
                float y_input = Input.GetAxis("Vertical") * speed;

                rb.velocity = new Vector3(x_input, 0, y_input);
                break;
        }

        if (rb.velocity.x > 0f)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x < 0f)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }
}
