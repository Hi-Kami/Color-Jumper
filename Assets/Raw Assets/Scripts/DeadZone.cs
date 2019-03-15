using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
	void Start(){}
	
	void Update(){}

    void OnTriggerEnter2D( Collider2D EnteredObject )
    {
        //Tmp Solution, later tag player and they lose a life or game ends
            EnteredObject.GetComponent<Rigidbody2D>().MovePosition( Vector2.zero );
            EnteredObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Reset Score
            EnteredObject.GetComponent<Player>().Reset();
    }
}
