using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColide : MonoBehaviour
{
    public float BounceForce = 10.0f;

	void Start()
    {
	}
	
	void Update()
    {
	}

    void OnTriggerEnter2D( Collider2D EnteredObject )
    {
        //If platform and player color the same
        if( EnteredObject.GetComponent<Player>().MyColor == gameObject.GetComponentInParent<Platform>().MyColor )
        {
            //Add force to player(ie the bounce)
                EnteredObject.GetComponent<Rigidbody2D>().AddForce( Vector2.up * 750.0f );

            //Add Score
                EnteredObject.GetComponent<Player>().Score++;
                EnteredObject.GetComponent<Player>().LvlUpCount++;

            //Trigger Jump animation
                EnteredObject.GetComponent<PlayerControl>().TriggerJumpAnimation();

            //Trigger Despawning of platform
                gameObject.GetComponentInParent<Platform>().TriggerDespawn();
        }
    }
}
