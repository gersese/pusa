using UnityEngine;

public class EnemyDamage : MonoBehaviour 
{
	const string TAG_PLAYER = "Player";
	const string TAG_EFFECTSMANAGER = "EffectsManager";
	const string TAG_VISUAL_EFFECT_MANAGER = "VisualEffect";
	
	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == TAG_PLAYER)
		{
			Vector3 playerPosition = c.gameObject.transform.position;
			
			AudioEffectsManager audioEffectsManager = GameObject.FindGameObjectWithTag(TAG_EFFECTSMANAGER)
				.GetComponent<AudioEffectsManager>();
			VisualEffect visualEffect = GameObject.FindGameObjectWithTag(TAG_VISUAL_EFFECT_MANAGER)
				.GetComponent<VisualEffect>();
			PlayerHealth playerHealth = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<PlayerHealth>();

			playerHealth.Damage(GetRandomDamage());
			visualEffect.PlayBloodEffect(playerPosition);
			audioEffectsManager.PlayDamageAudioEffect();
			
			Destroy(gameObject);
		}
	}

	int GetRandomDamage()
	{
		return Random.Range(15, 20);
	}
}
