using UnityEngine;
using System.Collections;

public class VisualEffect : MonoBehaviour
{
	const string TAG_BLOOD_PARTICLE = "Blood";
	const string TAG_POWERUP_EFFECT = "Effect";
	const int BLOOD_EMIT_RATE = 80;

	ParticleEmitter _particleEmitter = null;
	ParticleSystem _particleSystem = null;

	void Start()
	{
		_particleEmitter = GameObject.FindGameObjectWithTag("Effect").GetComponent<ParticleEmitter>();
		_particleSystem = GameObject.FindGameObjectWithTag(TAG_BLOOD_PARTICLE).GetComponent<ParticleSystem>();
	}

	public void PlayBloodEffect(Vector3 position)
	{
		_particleSystem.gameObject.transform.position = position;
		_particleSystem.Emit(BLOOD_EMIT_RATE);
	}

	public void PlayPowerupVisuals()
	{
		_particleEmitter.Emit();
	}

}

