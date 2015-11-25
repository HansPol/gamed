using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    [System.Serializable]
    public class CollectibleStats
    {
        public int value = 1;
    }

    public CollectibleStats stats = new CollectibleStats();
    
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null) {
            _player.AddPoints(stats.value);
            Destroy(gameObject);
            }
    }
    }