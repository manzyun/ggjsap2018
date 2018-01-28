using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawnInterface {
    void SpawnStart(List<Vector3> spawn_positions);
    float GetTimeLimit();
    int GetClearScore();
}
