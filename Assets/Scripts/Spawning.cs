using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{

    void Start()
    {

        if (spwn == null)
        {
            spwn = GameObject.FindGameObjectWithTag("SPWN").GetComponent<Spawning>();
        }

        }

    public static Spawning spwn;
    
    public GameObject collectablePrefab;        //prefab set in inspector
    Transform[] collectableSpawnPoint;          //spawnpoint array
    public float collectableSpawnDelay;         //spawning delay

    public IEnumerator StartSpawn()
    {
        collectableSpawnPoint = GetComponentsInChildren <Transform>();

        yield return new WaitForSeconds(collectableSpawnDelay); //spawn delay

        for (int i = 0; i < collectableSpawnPoint.Length; i++) //loop as many times as array length
        {
            int index = Random.Range(0, collectableSpawnPoint.Length); //Get random point on spawnpoint array
            var spawnpoint = collectableSpawnPoint[index];
            GameObject.Instantiate(collectablePrefab, spawnpoint.position, spawnpoint.rotation); //instantiate collectable on spawnpoint
        }
        //TODO: Zorg er voor dat tapes niet meerdere keren op hetzelfde punt gespawnd worden.

    }

        public static void Spawn(Spawning spawn) //public accessible void that starts spawning
    {
        spwn.StartCoroutine(spwn.StartSpawn());
    }
}

