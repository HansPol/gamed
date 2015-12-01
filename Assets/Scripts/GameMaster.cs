using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
     
    void Start (){
        if (gm == null){
            gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float SpawnDelay = 2;

          public IEnumerator RespawnPlayer ()
    {
        Debug.Log ("TODO: Spawn Sound");
        yield return new WaitForSeconds(SpawnDelay);

        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: Add Spawn Particles");
    }

    public static void KillPlayer(Player player) {
        Destroy(player.gameObject);

        GameObject[] coinsToDestoy = GameObject.FindGameObjectsWithTag("Coin");         //find all gameobject tagged coin and destroy and destroy them on player death
        foreach (GameObject Coin in coinsToDestoy ) {
            Destroy(Coin);
        }

        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
