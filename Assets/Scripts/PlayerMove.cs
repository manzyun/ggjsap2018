using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    /// <summary>
    /// 移動速度
    /// </summary>
    private float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 入力を取得
        float x_input = Input.GetAxis("Horizontal") * speed;
        float y_input = Input.GetAxis("Vertical") * speed;

        rb.velocity = new Vector3(x_input, 0, y_input);
    }
}
