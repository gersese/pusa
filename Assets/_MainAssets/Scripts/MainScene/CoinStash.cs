using UnityEngine;
using UnityEngine.UI;

public class CoinStash : MonoBehaviour 
{
	[SerializeField]
	GameObject _coinHUD;

	Text _currentCoins;
	int _coinsInStash = 0;

	void Start()
	{
		_currentCoins = _coinHUD.GetComponent<Text>();
	}

	void UpdateCoinHUD()
	{
		_currentCoins.text = ": "+ _coinsInStash.ToString();
	}

	public void EarnCoin(int coinValue)
	{
		_coinsInStash += coinValue;
		UpdateCoinHUD();
	}

	public int GetCoins()
	{
		return _coinsInStash;
	}
}
