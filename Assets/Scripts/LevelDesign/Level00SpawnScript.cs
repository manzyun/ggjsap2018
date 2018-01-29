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
        return 3500;
    }

    public float GetTimeLimit()
    {
        return 60.0f;
    }

    IEnumerator SpawnCoroutine()
    {
        while(true)
        {
            GameObject instance = Instantiate(human_prefab, spawn_positions[Random.Range(0, spawn_positions.Count)], Quaternion.identity);
            instance.GetComponent<HumanGender>().SetGender(Random.Range(0, 2) == 0 ? Gender.male : Gender.female);

            GameObject.Find("EnemySpawner").GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(Random.Range(0.75f, 1.25f));
        }
    }
}
