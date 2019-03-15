using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //Platform Color
        public PlatColor MyColor = PlatColor.Red;

    //Platform Size
        public float PlatformSize = 0.125f; //percent, 0.125f for closed


    //Platform anamation vars
        private float Speed = 3.0f;
        private float GoalScale = 0.0f;
        private bool Open = false;//true if opening, false if closing
        private bool Anamating = false;
        private bool Despawn = false;

    //Handles
        private GameObject PlatformEdgeLeft;
        private GameObject PlatformEdgeRight;
        private GameObject PlatformBeam;

    //Array ID
        public int ID;


	void Start()
    {
    }

	void Update()
    {
        //Update anamation of platform
            if( Anamating )
            {
                if( Open )//Opening
                {
                    if( PlatformSize < ( GoalScale - 0.01f ) )//if not fully opened
                    {
                        PlatformSize += ( Speed * Time.deltaTime );
                        ChangePlatformScale( PlatformSize );
                    }
                    else//if fully opened
                    {
                        Anamating = false;
                        PlatformSize = GoalScale;
                        ChangePlatformScale( PlatformSize );
                    }
                }
                else//closing
                {
                    if( PlatformSize > ( GoalScale + 0.01f ) )//If not fully closed
                    {
                        PlatformSize -= ( Speed * Time.deltaTime );
                        ChangePlatformScale( PlatformSize );
                    }
                    else//If fully closed
                    {
                        Anamating = false;
                        PlatformSize = GoalScale;
                        ChangePlatformScale( PlatformSize );
                    }
                }
            }
            else if( Despawn ) //Despawn Anamation
            {
                 if( PlatformSize > ( 0.126f ) )//If not fully closed
                 {
                    PlatformSize -= ( Speed * Time.deltaTime );
                    ChangePlatformScale( PlatformSize );
                 }
                 else//If fully closed
                 {
                    PlatformSize = GoalScale;
                    gameObject.GetComponentInParent<LevelManager>().RemovePlatform( ID );
                 }
            }
	}


    public void Link()
    {
        //Ref Peaces to handles
            PlatformEdgeLeft = gameObject.transform.Find( "PlatformEdgeLeft" ).gameObject;
            PlatformEdgeRight = gameObject.transform.Find( "PlatformEdgeRight").gameObject;
            PlatformBeam = gameObject.transform.Find( "PlatformBeam" ).gameObject;

        //Change to initial Color
            ChangeColor( MyColor );
    }

    public void ChangePlatformScale( float NewScale )
    {
        //Move Edges
            PlatformEdgeLeft.transform.localPosition = new Vector3( -NewScale, 0.0f );
            PlatformEdgeRight.transform.localPosition = new Vector3( NewScale, 0.0f );

        //Scale beam and collison box
            PlatformBeam.transform.localScale = new Vector3( ( 60.0f * NewScale), 1.0f );
    }

    public void OpenPlatform( float Scale, float Speed = 1.0f )
    {
        this.Speed = Speed;
        GoalScale = Scale;
        Open = true;
        Anamating = true;
    }

    public void ClosePlatform( float Scale, float Speed = 1.0f )
    {
        this.Speed = Speed;
        GoalScale = Scale;
        Open = false;
        Anamating = true;
    }

    public void ChangeColor( PlatColor NewColor )
    {
        MyColor = NewColor;

        if( MyColor == PlatColor.Red )
        {
            PlatformBeam.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if( MyColor == PlatColor.Blue )
        {
            PlatformBeam.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if( MyColor == PlatColor.Green )
        {
            PlatformBeam.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public void TriggerDespawn()
    {
        //Disable Collision
            PlatformBeam.GetComponent<Collider2D>().enabled = false;

        //Start Anamation
            Anamating = false;
            Despawn = true;
    }
}
