using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01SpawnScript : MonoBehaviour, SpawnInterface
{
    List<Vector3> spawn_positions;

    public void SpawnStart(List<Vector3> spawn_positions)
    {
        StartCoroutine("SpawnCoroutine");
    }

    public int GetClearScore()
    {
        return 20000;
    }

    public float GetTimeLimit()
    {
        return 90.0f;
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}
