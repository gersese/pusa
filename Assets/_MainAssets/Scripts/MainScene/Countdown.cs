using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour 
{
	float _countdown = 3.00f;

	Text _countdownHUD = null;

	void Start()
	{
		_countdownHUD = GetComponent<Text>();
	}

	void Update()
	{
		UpdateCountdown();
	}

	public void UpdateCountdown()
	{
		if(WillStop())
		{
			this.enabled = false;
			_countdownHUD.text = "GO";
		}
		else
		{
			_countdown -= Time.deltaTime;
			_countdownHUD.text = Mathf.RoundToInt(_countdown).ToString();
		}
	}

	public bool WillStop()
	{
		if(Mathf.RoundToInt(_countdown) == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
