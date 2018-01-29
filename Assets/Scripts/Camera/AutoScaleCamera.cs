using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaleCamera : MonoBehaviour
{
    [SerializeField]
    bool auto_rotate = true;
    [SerializeField]
    float width = 1280.0f;
    [SerializeField]
    float height = 720.0f;

    const float pixelperunit = 100.0f;
    Vector3 camera_pos = new Vector3(0, 32, 0);

    Camera main_camera;

    void Start()
    {
        main_camera = GetComponent<Camera>();

        transform.position = camera_pos;
        main_camera.orthographic = true;
        main_camera.orthographicSize = height * 0.5f / pixelperunit;

        SetViewPort();
    }

    void SetViewPort()
    {
        float screen_aspect = (float)Screen.height / (float)Screen.width;
        float game_aspect = height / width;

        if (game_aspect > screen_aspect)
        {
            float scale = height / Screen.height;
            float camera_width = width / (Screen.width * scale);
            main_camera.rect = new Rect((1.0f - camera_width) / 2.0f, 0f, camera_width, 1.0f);
        }
        else
        {
            float scale = width / Screen.width;
            float camera_height = height / (Screen.height * scale);
            main_camera.rect = new Rect(0f, (1.0f - camera_height) / 2.0f, 1.0f, camera_height);
        }
    }

    void Update()
    {
        SetViewPort();
    }
}