using UnityEngine;
using System.Collections;

public class ExplodingBlock : MonoBehaviour
{

    public float destroyDelay;

    public Transform destroyParticles;

    IEnumerator OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            yield return new WaitForSeconds(destroyDelay); //destroy delay
            Instantiate(destroyParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(gameObject);    //destroy block

        }
    }
}
