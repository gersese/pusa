using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	[SerializeField]
	GameObject _scoreHUD;

	GameManager _gameManager;
	Text _txtCurrentScore;

	int _currentScore = 0;
	int _scoreMultiplier = 8;

	void Start () 
	{
		_gameManager = GetComponent<GameManager>();
		_txtCurrentScore = _scoreHUD.GetComponent<Text>();
	}

	void UpdateScore()
	{
		if(!_gameManager.GameOver)
		{
			_currentScore += _scoreMultiplier;
			_txtCurrentScore.text = _currentScore.ToString(); 
		}
	}

	public void IncreaseScore(int bonusScore)
	{
		_currentScore += (_scoreMultiplier + bonusScore);
		UpdateScore();
	}

	public int GetScore()
	{
		return _currentScore;
	}
}
