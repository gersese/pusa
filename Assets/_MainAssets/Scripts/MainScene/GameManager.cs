using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	const string TAG_SPAWN_MANAGER = "SpawnManager";
	const string ENEMY_MANAGER = "EnemyManager";
	const string SCENE_NAME_MAIN_MENU = "MainMenuScene";
	const string TAG_COUNTDOWN = "Countdown";
	const string TAG_PLAYER = "Player";
	const string TAG_TIMER = "Timer";
	const string TAG_TOUCH = "Touch";
	const float RETURN_TO_MENU_DELAY = 3.0f;

	bool _isGameOver = false;
	bool _hasWritten = false;
	bool _hasGameStarted = false;

	Countdown _countdown;
	Timer _timer;
	SphereCollider _playerCollider;
	void Start()
	{
		_countdown = GameObject.FindGameObjectWithTag(TAG_COUNTDOWN).GetComponent<Countdown>(); 
		_timer = GameObject.FindGameObjectWithTag(TAG_TIMER).GetComponent<Timer>();
		_playerCollider = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<SphereCollider>();
	}

	void Update () 
	{
		if(IsCountdownFinised())
		{
			_hasGameStarted = true;
			SetComponentsEnabled(true);
			_countdown.gameObject.SetActive(false);
		}

		if(GameOver)
		{
			if(!_hasWritten)
			{
				SetComponentsEnabled(false);

				WriteGameData();
				_hasWritten = true;

				StartCoroutine(ReturnToMainMenu(false));
			}
		}
	}

	void WriteGameData()
	{
		ScoreManager scoreManager = GetComponent<ScoreManager>();
		CoinStash coinStash = GetComponent<CoinStash>();

		GameDataWriter gameDataWriter = new GameDataWriter();
		GameDataReader gameDataReader = new GameDataReader();
		GameData gameData = new GameData();

		gameData.Highscore = scoreManager.GetScore();
		gameData.Coins = coinStash.GetCoins();
		gameData.BestTime = _timer.GetTimeElapsed();
		gameData.Music = gameDataReader.GetGameData().Music;
		gameData.Effect = gameDataReader.GetGameData().Effect;
        
		gameDataWriter.WriteGameData(gameData);
	}
	
	public IEnumerator ReturnToMainMenu(bool hasPaused)
	{
		if(!hasPaused)
		{
			yield return new WaitForSeconds(RETURN_TO_MENU_DELAY);
		}

		Application.LoadLevel(SCENE_NAME_MAIN_MENU);
	}

	bool IsCountdownFinised()
	{
		if(!_countdown.enabled && !_hasGameStarted)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool GameStarted
	{
		get{ return _hasGameStarted; }
	}

	public bool GameOver
	{
		get{ return _isGameOver; }
		set{ _isGameOver = value; }
	}

	void SetComponentsEnabled(bool isEnabled)
	{
		EnemyManager enemyManager = GameObject.FindGameObjectWithTag(ENEMY_MANAGER).GetComponent<EnemyManager>();
		InputManager inputManager = GameObject.FindGameObjectWithTag(TAG_TOUCH).GetComponent<InputManager>();
		
		GameObject spawnManager = GameObject.FindGameObjectWithTag(TAG_SPAWN_MANAGER);

		CoinSpawn coinSpawn = spawnManager.GetComponent<CoinSpawn>(); 
		PowerupSpawn powerupSpawn = spawnManager.GetComponent<PowerupSpawn>();
		HealSpawn healSpawn = spawnManager.GetComponent<HealSpawn>();
		
		_countdown.gameObject.SetActive(isEnabled);
		_playerCollider.enabled = isEnabled;
		enemyManager.enabled = isEnabled;
		coinSpawn.enabled = isEnabled;
		powerupSpawn.enabled = isEnabled;
		healSpawn.enabled = isEnabled;
		_timer.enabled = isEnabled;
		inputManager.enabled = isEnabled;
		_hasGameStarted = isEnabled;
	}
}
