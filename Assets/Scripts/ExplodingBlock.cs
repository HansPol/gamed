using UnityEngine;
using System.Collections;

public class ExplodingBlock : MonoBehaviour {

    public int destroyDelay;

    IEnumerator OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            yield return new WaitForSeconds(destroyDelay); //destroy delay
            Destroy(gameObject);    //destroy block
        }
    }
}
