using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
		DontDestroyOnLoad ( GameObject.FindGameObjectWithTag( "Player" ));
		DontDestroyOnLoad ( GameObject.FindGameObjectWithTag( "MainCamera" ));
		Application.LoadLevel("Level2");
		explodingBlockSpawn.Spawn(null);
    }

}