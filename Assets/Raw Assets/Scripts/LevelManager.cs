using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Handles
        public Transform MinSpawnArea = null;
        public Transform MaxSpawnArea = null;

        public GameObject PlatformHandle = null;

    //Platform management
        private GameObject[] PlatformList;
        private int PlatformCount = 0;

    //SpawnTimer
        private float SpawnDelay = 0.0f;

    //Random
        private System.Random RandomNumber = new System.Random();
        private System.Random RandomColor = new System.Random();

    //Current platform Modifyer
        private float PlatMod = 1.0f;

        public float PlatformMinSize = 0.35f;
        public float LevelDeduction = 0.05f;

	void Start()
    {
        PlatformList = new GameObject[8];
        for(int i = 0; i < 8; i++ )
        {
            PlatformList[i] = null;
        }
        
        //Spawn 3 red platforms to start
            
            //First Spawn
                PlatformList[0] = (GameObject)Instantiate( PlatformHandle, new Vector3( 0.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[0].GetComponent<Platform>().Link();
                PlatformList[0].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[0].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[0].gameObject.GetComponent<Platform>().ID = 0;

            //Second Spawn
                PlatformList[1] = (GameObject)Instantiate( PlatformHandle, new Vector3( 3.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[1].GetComponent<Platform>().Link();
                PlatformList[1].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[1].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[1].GetComponent<Platform>().ID = 1;
            
            //First Spawn
                PlatformList[2] = (GameObject)Instantiate( PlatformHandle, new Vector3( -3.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[2].GetComponent<Platform>().Link();
                PlatformList[2].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[2].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[2].GetComponent<Platform>().ID = 2;

            PlatformCount = 3;
	}
	
	void Update()
    {
        if( SpawnDelay > 0.0f )
        {
            SpawnDelay -= Time.deltaTime;
        }
        else
        {
            //Set New Time
                SpawnDelay = ( float )( RandomNumber.NextDouble() * 1.75 );

            if( !( PlatformCount > 7 ) )
            {
                //Increment count
                    PlatformCount++;

                //Find a empty Array pos
                for( int i = 0; i < 8; i++ )
                {
                    if( PlatformList[i] == null )
                    {
                        //Generate position between handle pos
                            Vector3 RandomPos = new Vector3
                                ( 
                                    (float)( RandomNumber.NextDouble() * ( MaxSpawnArea.transform.position.x - MinSpawnArea.transform.position.x ) + MinSpawnArea.transform.position.x ),
                                    (float)( RandomNumber.NextDouble() * ( MaxSpawnArea.transform.position.y - MinSpawnArea.transform.position.y ) + MinSpawnArea.transform.position.y )
                                );

                        //Create Object in array
                            PlatformList[i] = (GameObject)Instantiate( PlatformHandle, RandomPos, new Quaternion(), this.transform );

                        //Link Children
                            PlatformList[i].GetComponent<Platform>().Link();

                        //GiveID
                            PlatformList[i].GetComponent<Platform>().ID = i;

                        //Start open anamation
                            PlatformList[i].GetComponent<Platform>().OpenPlatform( ( PlatMod ) );

                        //Spawn New Platform
                            switch( RandomColor.Next( 0, 3 ) )
                            {
                                case 0://Red
                                    //SetColor
                                        PlatformList[i].GetComponent<Platform>().ChangeColor( PlatColor.Red );
                                break;
                                case 1://blue
                                    //SetColor
                                        PlatformList[i].GetComponent<Platform>().ChangeColor( PlatColor.Blue );
                                break;
                                case 2://green
                                    //SetColor
                                        PlatformList[i].GetComponent<Platform>().ChangeColor( PlatColor.Green );
                                break;
                            }
                        break;
                    }
                }

                
            } 
        }
	}

    public void RemovePlatform( int ID )
    {
        //Destroy platform
            Destroy( PlatformList[ID] );

        //Reset array pos to null
            PlatformList[ID] = null;

        //Remove from count
            PlatformCount--;
    }

    public void ScaleDown()
    {
        if( PlatMod > PlatformMinSize )
        {
            PlatMod -= LevelDeduction;
        }
    }

    public void ResetLevel()
    {
        //Wipe Platform List
            for( int i = 0; i < PlatformList.Length; i++ )
            {
                RemovePlatform( i );
            }
            PlatformCount = 0;

        //Create 3 basic Platforms
            //Spawn 3 red platforms to start
            
            //First Spawn
                PlatformList[0] = (GameObject)Instantiate( PlatformHandle, new Vector3( 0.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[0].GetComponent<Platform>().Link();
                PlatformList[0].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[0].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[0].gameObject.GetComponent<Platform>().ID = 0;

            //Second Spawn
                PlatformList[1] = (GameObject)Instantiate( PlatformHandle, new Vector3( 3.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[1].GetComponent<Platform>().Link();
                PlatformList[1].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[1].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[1].GetComponent<Platform>().ID = 1;
            
            //First Spawn
                PlatformList[2] = (GameObject)Instantiate( PlatformHandle, new Vector3( -3.0f, -4.0f ), new Quaternion(), this.transform );
                PlatformList[2].GetComponent<Platform>().Link();
                PlatformList[2].GetComponent<Platform>().ChangePlatformScale( 1.0f );
                PlatformList[2].GetComponent<Platform>().PlatformSize = 1.0f;
                PlatformList[2].GetComponent<Platform>().ID = 2;

            PlatformCount = 3;
            
        //Reset Modifyer
            PlatMod = 1.0f;

    }
}
