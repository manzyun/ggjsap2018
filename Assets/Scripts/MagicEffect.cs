using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEffect : MonoBehaviour {
    [SerializeField]
    float degree,
        speed,
        duration;
    [SerializeField]
    GameObject magic_prefab;
    [SerializeField]
    Sprite[] magic_sprites;
    [SerializeField]
    int magic_num;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && IsMousePositionOnGround())
        {
            for (int i = 0; i < magic_num; i++)
            {
                Vector3 mouse_world_pos = GetMouseWorldPosition();
                float angle = Mathf.Atan2(mouse_world_pos.z - transform.position.z, mouse_world_pos.x - transform.position.x) * Mathf.Rad2Deg;
                Vector3 direction = GetRandomVector(angle);

                float random_duration = Random.Range(0, duration);

                GameObject child = Instantiate(magic_prefab, transform);
                child.transform.position = transform.position + new Vector3(0, 0.01f, 0) + direction * speed * random_duration;
                child.GetComponent<MagicMove>().Setup(direction, speed, duration - random_duration, magic_sprites[Random.Range(0, magic_sprites.Length)]);
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    Vector3 mouse_world_pos = GetMouseWorldPosition();
            //    float angle = Mathf.Atan2(mouse_world_pos.z - transform.position.z, mouse_world_pos.x - transform.position.x) * Mathf.Rad2Deg;
            //    Vector3 direction = GetRandomVector(angle);

            //    GameObject child = Instantiate(magic_prefab, transform);
            //    child.transform.position = transform.position + new Vector3(0, 0.01f, 0);
            //    child.GetComponent<MagicMove>().Setup(direction, speed, duration, magic_sprites[Random.Range(0, magic_sprites.Length)]);
            //}
        }
	}

    bool IsMousePositionOnGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = LayerMask.GetMask("Ground");
        return Physics.Raycast(ray, 1000, layerMask);
    }

    Vector3 GetMouseWorldPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        int layerMask = LayerMask.GetMask("Ground");
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    Vector3 GetRandomVector(float angle)
    {
        float random_angle = angle + Random.Range(-degree, degree);
        return new Vector3(Mathf.Cos(random_angle * Mathf.Deg2Rad), 0, Mathf.Sin(random_angle * Mathf.Deg2Rad));
    }
}
