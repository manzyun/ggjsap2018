using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawnInterface {
    void SpawnStart(List<Vector3> spawn_positions, GameObject human_prefab);
    float GetTimeLimit();
    int GetClearScore();
}
