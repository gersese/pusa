using UnityEngine;

public class AttackPowerup : Powerup 
{
	const string TAG_PLAYER = "Player";
	const string TAG_GAMEMANAGER = "GameManager";

	void Update () 
	{
		Move();
	}

	void OnTriggerEnter(Collider c)
	{
		if(HasAcquiredByPlayer(c))
		{
			GetPowerupEffect();
			Destroy(gameObject);
		}
	}

	protected override void GetPowerupEffect()
	{
		GameObject player = GameObject.FindGameObjectWithTag(TAG_PLAYER);

		PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
		PlayerAttack playerAttack = player.GetComponent<PlayerAttack>();

		playerMovement.SetRotate(true);
		playerAttack.SetFiringEnabled(true);
	}

}
