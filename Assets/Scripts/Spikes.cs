using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour 
{
	public int damageAmount;

	public void OnCollisionEnter2D(Collision2D other)
	{
		Player.Instance.DamagePlayer(damageAmount);
	}


}
