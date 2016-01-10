using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static Player Instance;

    [System.Serializable]
	public class PlayerStats {

	public int Health = 100;
    public int Score = 0;

	}

	public PlayerStats playerStats = new PlayerStats();

    public int FallBoundary = -20;

    public void AddPoints(int value) {
        playerStats.Score += value;
    }

    
     void Update () {
        if (transform.position.y <= FallBoundary)
            DamagePlayer (999999999);
    }
    
    void Start()
    {
        Spawning.Spawn(null);
        explodingBlockSpawn.Spawn(null);

    }

    public void DamagePlayer (int damage){
		playerStats.Health -= damage;
		if (playerStats.Health <= 0){
            GameMaster.KillPlayer(this);
		}
	}
 }