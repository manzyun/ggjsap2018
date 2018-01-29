using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanDetectAnimeState : MonoBehaviour {

    [SerializeField]
    float stop_velocity;
    NavMeshAgent agent;
    public HumanAnimeState state = HumanAnimeState.Stand;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update() {
        if(agent.velocity.magnitude <= stop_velocity)
        {
            state = HumanAnimeState.Stand;
        }
        else if(agent.velocity.x < 0)
        {
            state = HumanAnimeState.Left;
        }
        else
        {
            state = HumanAnimeState.Right;
        }

        //Debug.Log(state);
	}
}

public enum HumanAnimeState
{
    Stand, Left, Right
}


