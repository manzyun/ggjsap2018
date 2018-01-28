using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00SpawnScript : MonoBehaviour, SpawnInterface {
    List<Vector3> spawn_positions;
    GameObject human_prefab;

    public void SpawnStart(List<Vector3> spawn_positions, GameObject human_prefab)
    {
        this.spawn_positions = spawn_positions;
        this.human_prefab = human_prefab;

        StartCoroutine("SpawnCoroutine");
    }

    public int GetClearScore()
    {
        return 10000;
    }

    public float GetTimeLimit()
    {
        return 90.0f;
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            Instantiate(human_prefab, spawn_positions[Random.Range(0, spawn_positions.Count)], Quaternion.identity);

            yield return new WaitForSeconds(1);
        }
        //Instantiate(human_prefab, spawn_positions[0], Quaternion.identity);

        yield return null;
    }
}
