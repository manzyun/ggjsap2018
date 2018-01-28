using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanBodyAnime : MonoBehaviour {

    [SerializeField]
    float STOP_VELOCITY_X;
    private NavMeshAgent navMesh;
    public HumanAnimeState State = HumanAnimeState.Stand;

    Vector3 old_pos;

    [SerializeField]
    Sprite[] walk_animes;

    [SerializeField]
    SpriteRenderer body_sprite_render;

	// Use this for initialization
	void Start () {

        navMesh = this.GetComponent<NavMeshAgent>();
        old_pos = transform.position;
	}

    // Update is called once per frame
    void Update() {

        Vector3 velocity = transform.position - old_pos;
        old_pos = transform.position;

        if (velocity.magnitude <= STOP_VELOCITY_X)
        {
            State = HumanAnimeState.Stand;
        }
        else if (velocity.x < 0)
        {
            State = HumanAnimeState.Left;
        }
        else
        {
            State = HumanAnimeState.Right;
        }

        //Debug.Log(State);

        SetAnimation();
		
	}

    float anime_timer = 0.0f;
    HumanAnimeState old_state = HumanAnimeState.Stand;
   void SetAnimation()
    {
        if(State == HumanAnimeState.Stand)
        {
            old_state = HumanAnimeState.Stand;
            body_sprite_render.sprite = walk_animes[0];
        }
        else if(old_state != HumanAnimeState.Left && State == HumanAnimeState.Left)
        {
            anime_timer = 0.0f;
            old_state = HumanAnimeState.Left;
            body_sprite_render.sprite = walk_animes[1];
        }
        else if (old_state != HumanAnimeState.Right && State == HumanAnimeState.Right)
        {
            anime_timer = 0.0f;
            old_state = HumanAnimeState.Right;
            body_sprite_render.sprite = walk_animes[2];
        }
    }
}

public enum HumanAnimeState
{
    Stand, Left, Right
}


