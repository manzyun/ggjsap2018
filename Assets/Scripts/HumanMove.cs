using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMove : MonoBehaviour {

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {

        agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(new Vector3(2, 0, 2));


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
