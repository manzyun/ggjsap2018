using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    [SerializeField]
    float x_offset;

    [SerializeField]
    Transform[] spawn_points;

    SpawnInterface script;

    // Use this for initialization
    void Awake () {
        if (script == null)
        {
            switch (GameObject.Find("GameInstance").GetComponent<GameInstanceComponent>().level_index)
            {
                case 0:
                    gameObject.AddComponent(typeof(Level00SpawnScript));
                    break;
                default:
                    gameObject.AddComponent(typeof(Level01SpawnScript));
                    break;
            }

            script = GetComponent<SpawnInterface>();
        }
    }

    public void SpawnStart()
    {
        if(script == null)
        {
            Awake();
        }

        List<Vector3> spawn_positions = new List<Vector3>();
        foreach (Transform spawn_point in spawn_points)
        {
            spawn_positions.Add(spawn_point.position + new Vector3(x_offset, 0, 0));
        }

        GetComponent<SpawnInterface>().SpawnStart(spawn_positions);
    }

    public float GetTimeLimit()
    {
        if (script == null)
        {
            Awake();
        }

        return script != null ? script.GetTimeLimit() : 0;
    }

    public int GetClearScore()
    {
        if (script == null)
        {
            Awake();
        }

        return script != null ? script.GetClearScore() : 0;
    }
}
