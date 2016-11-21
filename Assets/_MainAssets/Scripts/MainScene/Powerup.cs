using UnityEngine;

public class Powerup : MonoBehaviour 
{
	const string TAG_PLAYER = "Player";
	const string TAG_VISUAL_EFFECT_MANAGER = "VisualEffect";

	const float POWERUP_MOVE_SPEED = 4.00f;

	VisualEffect _visualEffect = null;
	
	protected virtual void GetPowerupEffect(){}

	protected virtual void Destroy(){}

	protected virtual void Move()
	{
		Vector3 direction = new Vector3(-POWERUP_MOVE_SPEED, 0, 0);
		transform.Translate(direction * Time.deltaTime);
	}

	protected bool HasAcquiredByPlayer(Collider objectCollided)
	{
		if(objectCollided.tag == TAG_PLAYER)
		{	
			_visualEffect = GameObject.FindGameObjectWithTag(TAG_VISUAL_EFFECT_MANAGER).GetComponent<VisualEffect>();
			_visualEffect.PlayPowerupVisuals();
			return true;
		}
		else
		{
			return false;
		}
	}

}
