using UnityEngine;

public class Poop : MonoBehaviour 
{
	const float SPEED = 30.00f;
	const float UNITS_AWAY = 20.00f;
	const string TAG_GAMEMANAGER = "GameManager";
	const string TAG_ENEMY = "Enemy";
	const int BONUS_SCORE = 50;
	const int BONUS_COINS = 20;

	Vector3 _direction;

	CoinStash _coinStash;
	ScoreManager _scoreManager;

	void Start()
	{
		_scoreManager = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<ScoreManager>();
		_coinStash = GameObject.FindGameObjectWithTag(TAG_GAMEMANAGER).GetComponent<CoinStash>();
	}

	void Update () 
	{
		LaunchPoop();
	}

	void LaunchPoop()
	{	
		_direction = new Vector3(UNITS_AWAY, transform.position.y, 0);
		transform.position = Vector3.MoveTowards(transform.localPosition, _direction , (SPEED * Time.deltaTime)) ;
	}

	void OnTriggerEnter(Collider c)
	{
		if(HasHittedEnemy(c.gameObject))
		{
			_scoreManager.IncreaseScore(BONUS_SCORE);
			_coinStash.EarnCoin(BONUS_COINS);

			Destroy(c.gameObject);
			Destroy(gameObject);
		}
	}

	bool HasHittedEnemy(GameObject hit)
	{
		if(hit.tag == TAG_ENEMY)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
