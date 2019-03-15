using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //Jump Cooldown
        public float JumpCooldown = 5.0f;
        public GameObject JumpTextHandle = null;

    //Jump Controls
        private bool CanJump = true;
        private float JumpCooldownTime;
        private float BounceCooldownTime;

    //Atune Cooldown
        public float AtuneCooldown = 5.0f;
        public GameObject AtuneTextHandle = null;
        
    //Atune Controls
        private bool CanAtune = true;
        private float AtuneCooldownTime;
        private PlatColor CurrentAtunement = PlatColor.Red;

    //Handles for frames
        public Sprite DefaultFrame = null;
        public Sprite JumpFrameOne = null;
        public Sprite JumpFrameTwo = null;
        public Sprite JumpFrameThree = null;


    //Test output
        public GameObject TestTextOutput = null;


	void Start()
    {
		
	}
	
	void Update()
    {
         ////////////////
		//Emergency Jump

            //If can jump
            if( CanJump )
            {
                if( Input.GetKeyDown( KeyCode.Space ) )//then check if space hit
                {
                    //if so jump
                        gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.up * 750.0f );
                        CanJump = false;
                        JumpCooldownTime = JumpCooldown;

                    //Anamate
                        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = JumpFrameThree;
                        BounceCooldownTime = 1.0f;
                }
            }
            else//If cant, tick timer down
            {
                JumpCooldownTime -= Time.deltaTime;
                JumpTextHandle.GetComponent<Text>().text = "CanJump: " + JumpCooldownTime;
                if( JumpCooldownTime < 0.001f )
                {
                    CanJump = true;
                    JumpTextHandle.GetComponent<Text>().text = "CanJump: Yes";
                }
            }

         ///////////
        //Movement

            //Move Left 
                if( Input.GetKey( KeyCode.A ) )
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.left * 7.5f );
                }

            //Move Right
                if( Input.GetKey( KeyCode.D ) )
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.right * 7.5f );
                }

         ///////////
        //Atunement

           
            if(
                Input.GetKey( KeyCode.Alpha1 ) 
                && CanAtune
                && gameObject.GetComponent<Player>().MyColor != PlatColor.Red
              )//Red
            {
                //Set Player to red
                    gameObject.GetComponent<Player>().MyColor = PlatColor.Red;
                    gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

                //Disable atunement
                    CanAtune = false;

                //SetCooldown
                    AtuneCooldownTime = AtuneCooldown;
            }
            else if(
                Input.GetKey( KeyCode.Alpha2 ) 
                && CanAtune
                && gameObject.GetComponent<Player>().MyColor != PlatColor.Blue
              )//Blue
            {
                //Set Player to red
                    gameObject.GetComponent<Player>().MyColor = PlatColor.Blue;
                    gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;

                //Disable atunement
                    CanAtune = false;

                //SetCooldown
                    AtuneCooldownTime = AtuneCooldown;
            }
            else if(
                Input.GetKey( KeyCode.Alpha3 ) 
                && CanAtune
                && gameObject.GetComponent<Player>().MyColor != PlatColor.Green
              )//Green
            {
                //Set Player to red
                    gameObject.GetComponent<Player>().MyColor = PlatColor.Green;
                    gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;

                //Disable atunement
                    CanAtune = false;

                //SetCooldown
                    AtuneCooldownTime = AtuneCooldown;
            }
            else//Tick
            {
                AtuneCooldownTime -= Time.deltaTime;
                AtuneTextHandle.GetComponent<Text>().text = "Atune: " + AtuneCooldownTime;
                if( AtuneCooldownTime < 0.001f )
                {
                    CanAtune = true;
                    AtuneTextHandle.GetComponent<Text>().text = "Atune: Yes";
                }
            }

            //Close Program
            if( Input.GetKey( KeyCode.Escape ) )
            {
                Application.Quit();
            } 

            //Anamate
            //if( ( gameObject.GetComponent<Rigidbody2D>().velocity.y < 5.1f ) && ( BounceCooldownTime < 0.01f ) )
            //{
            //    gameObject.GetComponentInChildren<SpriteRenderer>().sprite = DefaultFrame;
            //}
            //else if( ( gameObject.GetComponent<Rigidbody2D>().velocity.y < 2.6f ) && ( BounceCooldownTime < 0.01f ) )
            //{
            //    gameObject.GetComponentInChildren<SpriteRenderer>().sprite = DefaultFrame;
            //}
            if( ( gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.1f ) && ( BounceCooldownTime < 0.01f ) )
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().sprite = DefaultFrame;
            }

            BounceCooldownTime -= Time.deltaTime;

            TestTextOutput.GetComponent<Text>().text = "Speed: " + gameObject.GetComponent<Rigidbody2D>().velocity.y;
	}

    public void TriggerJumpAnimation()
    {
        //Anamate
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = JumpFrameThree;
            BounceCooldownTime = 1.0f;
    }
}
