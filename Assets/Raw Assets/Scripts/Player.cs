using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlatColor MyColor = PlatColor.Red;

    public int Score = 0;

    public GameObject ScoreTextHandle = null;

    public GameObject LevelHandle = null;

    public int LvlUpCount = 0;

    private int Best = 0;

	void Start()
    {
	}
	
	void Update()
    {
        ScoreTextHandle.GetComponent<Text>().text = "Score: " + Score + "    Best: " + Best;

        if( LvlUpCount == 10 )
        {
            LvlUpCount = 0;
            LevelHandle.GetComponent<LevelManager>().ScaleDown();
        }
	}

    public void Reset()
    {
        //If best score, store
            if( Score > Best )
            {
                Best = Score;
            }

        //Wipe scores
            Score = 0;
            LvlUpCount = 0;

        //Reset Level
             LevelHandle.GetComponent<LevelManager>().ResetLevel();
    }
}
