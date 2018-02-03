using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStateComponent : MonoBehaviour
{
    public HumanState state { get; private set; }
    // Use this for initialization
    void Start()
    {
        state = HumanState.Idle;

    }
    public void SetState(HumanState state)
    {
        this.state = state;
    }
}
    public enum HumanState
{
    Idle,
    Walk,
    Dead
};