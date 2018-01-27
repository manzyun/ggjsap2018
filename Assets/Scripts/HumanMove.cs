using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanMove : MonoBehaviour {
    //Components
    private NavMeshAgent agent;
    private Rigidbody rigid;
    private HumanStateComponent state_com;
    private HumanLaught humanLaught;
    private GameObject PLAYER;

    //SerializeField
    [SerializeField]
    float DEFULT_WALK_SPEED;
    [SerializeField]
    float close_distance;

    //Value
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

        SetComponents();

        
    }

    void SetComponents()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        rigid = this.gameObject.GetComponent<Rigidbody>();
        state_com = GetComponent<HumanStateComponent>();
        humanLaught = GetComponent<HumanLaught>();
        PLAYER = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
        SetWalkSpeed();

        if(state_com.state == HumanState.Idle)
        {
            if(GetDistanceWithPlayer() <= close_distance)
            {
                state_com.SetState(HumanState.Walk);
                GoRandomPosition();
            }
        }
        else if(state_com.state == HumanState.Walk)
        {
            if((new Vector3(transform.position.x, 0, transform.position.z) - randomPosition).magnitude <= 0.1f)
            {
                state_com.SetState(HumanState.Idle);
            }
        }
    }

    void GoRandomPosition()
    {
        while (true)
        {
            if (GoingPositionGet())
            {
                break;
            }
        };
    }


    bool GoingPositionGet()
    {
        randomPsitionX = Random.Range(MIN_X_POSITION, MAX_X_POSITION + 1);
        randomPsitionZ = Random.Range(MIN_Z_POSITION, MAX_Z_POSITION + 1);

        ray = new Ray(new Vector3(randomPsitionX, 1, randomPsitionZ), new Vector3(0, -5, 0));

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        randomPosition = new Vector3(randomPsitionX, 0, randomPsitionZ);

        LayerMask ground_mask = LayerMask.GetMask("Ground");
        LayerMask house_mask = LayerMask.GetMask("House");

        if (Physics.Raycast(ray, 100, ground_mask) && Physics.Raycast(ray, 100, house_mask) == false)
        {
            movementrange = Vector3.Distance(this.transform.position, randomPosition);

            if (movementrange < MOVEMENT_LIMIT)
            {

                agent.SetDestination(new Vector3(randomPsitionX, 0, randomPsitionZ));
                return true;
            }
        }

        return false;
    }

    void SetWalkSpeed()
    {
        agent.speed = DEFULT_WALK_SPEED * CalculateWalkRate(humanLaught.laught);
    }

    float CalculateWalkRate(float laught_value)
    {
        return 1.0f - laught_value;
    }
    
    float GetDistanceWithPlayer()
    {
        return Vector3.Distance(this.transform.position, PLAYER.transform.position);
    }
}
