using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMove : MonoBehaviour {
    [SerializeField]
    SpriteRenderer magic_sprite;

    Vector3 direction;
    float speed;
    float duration;

    public void Setup(Vector3 direction, float speed, float duration, Sprite sprite)
    {
        this.direction = direction;
        this.speed = speed;
        this.duration = duration;
        this.magic_sprite.sprite = sprite;
    }

	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration);
	}
	
	// Update is called once per frame
	void Update () {
        magic_sprite.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

        transform.position += direction * speed * Time.deltaTime;
	}
}
