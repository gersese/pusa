using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	const string TAG_GAME_MANAGER = "GameManager";
	const string TEXT_GAME_OVER = "Game Over :(";
	const int MAX_HEALTH = 100;
	const int DAMAGE_OVER_TIME = 2;
	const int SECONDS_TO_DAMAGE = 1;

	int _currentHealth = 0;

	[SerializeField]
	GameObject _healthHUD;

	Scrollbar _currentHealthHUD;
	GameManager _gameManager;

	void Start () 
	{
		_gameManager = GameObject.Find(TAG_GAME_MANAGER).GetComponent<GameManager>();
		_currentHealthHUD = _healthHUD.GetComponent<Scrollbar>();

		_currentHealth = MAX_HEALTH;
		
		StartCoroutine(DecreasePlayerLifeOverTime());
	}

	public void Damage(int damage)
	{
		_currentHealth -= damage;

		if(!IsAlive())
		{
			_currentHealth = 0;
			_gameManager.GameOver = true;
			DisposePlayer();
		}
		UpdateHealthHUD();
	}

	IEnumerator DecreasePlayerLifeOverTime()
	{
		yield return new WaitForSeconds( SECONDS_TO_DAMAGE );

		if(_gameManager.GameStarted)
		{
			Damage(DAMAGE_OVER_TIME);
		}
		

		StartCoroutine(DecreasePlayerLifeOverTime());
	}

	void DisposePlayer()
	{
		gameObject.SetActive(false);
	}

	public void Heal(int heal)
	{
		_currentHealth += heal;
		
		if(IsHealthFull())
		{
			_currentHealth = MAX_HEALTH;
		}
		UpdateHealthHUD();
	}

	public void UpdateHealthHUD()
	{
		float lifebarSize = (float) _currentHealth / 100;
		_currentHealthHUD.size = lifebarSize;

		if(!IsAlive())
		{
			_currentHealthHUD.transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	public int GetCurrentHealth()
	{
		return _currentHealth;
	}
	
	bool IsHealthFull()
	{
		if(_currentHealth >= MAX_HEALTH)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public bool IsAlive()
	{
		if(_currentHealth > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
