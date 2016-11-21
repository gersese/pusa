using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	const string BUTTON_ARG = "Fire1";
	const float FIRE_RATE = 0.30f;
	const float DURATION = 7.00f;

	bool _canFire = false;

	[SerializeField]
	GameObject _poop;
	
	void Start () 
	{
		InvokeRepeating("Fire", 0, FIRE_RATE);
	}

	bool HasFired()
	{
		if(Input.GetButton(BUTTON_ARG) && _canFire)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void Fire()
	{
		if(HasFired())
		{
			Instantiate(_poop, transform.localPosition, Quaternion.identity);
		}
	}

	IEnumerator Fireable()
	{
		yield return new WaitForSeconds(DURATION);
		_canFire = false;
	}

	public void SetFiringEnabled(bool canFire)
	{
		_canFire = canFire;
		StartCoroutine(Fireable());
	}

}
