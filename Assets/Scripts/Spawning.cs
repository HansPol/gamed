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


    public Transform collectablePrefab;
    public Transform collectableSpawnPoint;
    public float collectableSpawnDelay;

    public IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(collectableSpawnDelay);

        Instantiate(collectablePrefab, collectableSpawnPoint.position, collectableSpawnPoint.rotation);
    }

    public static void Spawn(Spawning spawn)
    {
        spwn.StartCoroutine(spwn.StartSpawn());
    }
}