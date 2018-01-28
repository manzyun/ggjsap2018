using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMove : MonoBehaviour {

    [SerializeField]
    float DEFULT_WALK_SPEED;
    private NavMeshAgent agent;
    private HumanLaught humanLaught;
    private float MAX_X_POSITION = 5.8f,
                  MIN_X_POSITION = -5.8f,
                  MAX_Z_POSITION = 3f,
                  MIN_Z_POSITION = -3f,
                  randomPsitionX,
                  randomPsitionZ,
                  MOVEMENT_LIMIT = 5,
                  movementrange;
    private Ray ray;
    private Vector3 randomPosition;
    private bool getPositionFrag = false;

  
    // Use this for initialization
    void Start () {

        humanLaught = GetComponent<HumanLaught>();

        agent = this.gameObject.GetComponent<NavMeshAgent>();
        // agent.SetDestination(new Vector3(2, 0, 2));

        //while (getPositionFrag == false)
        //{
        //    print("dd");
        //    GoingPositionGet();
        //};
    }

    // Update is called once per frame
    void Update () {

        SetWalkSpeed();
    }


    private void GoingPositionGet()
    {
        print("aa");

        randomPsitionX = Random.Range(MIN_X_POSITION, MAX_X_POSITION + 1);
        randomPsitionZ = Random.Range(MIN_Z_POSITION, MAX_Z_POSITION + 1);

        ray = new Ray(new Vector3(randomPsitionX, 1, randomPsitionZ),new Vector3(0,-5,0));

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        randomPosition = new Vector3(randomPsitionX, 0, randomPsitionZ);

        LayerMask ground_mask = LayerMask.GetMask("Ground");
        LayerMask house_mask = LayerMask.GetMask("House");

        if(Physics.Raycast(ray, 100, ground_mask) && Physics.Raycast(ray, 100, house_mask) == false)
        {
            movementrange = Vector3.Distance(this.transform.position, randomPosition);

            if (movementrange < MOVEMENT_LIMIT)
            {

                agent.SetDestination(new Vector3(randomPsitionX, 0, randomPsitionZ));
                getPositionFrag = true;
            }
        }
    }

    void SetWalkSpeed()
    {
        agent.speed = DEFULT_WALK_SPEED * CalculateWalkRate(humanLaught.laught);
    }

    float CalculateWalkRate(float laught_value)
    {
        return 1.0f - laught_value;
    }
    
}
