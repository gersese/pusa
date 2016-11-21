using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour 
{
	const float BLINK_TIME = 0.5f;

	float _alpha = 0.0f;

	void Start()
	{
		InvokeRepeating("Blink", 1, BLINK_TIME);
	}

	void Blink()
	{
		Color component = transform.GetComponent<Text>().color;
		transform.GetComponent<Text>().color = new Color(component.r, component.g, component.b, _alpha);

		if(_alpha == 0.0f)
		{
			_alpha = 1.0f;
		}
		else
		{
			_alpha = 0.0f;
		}
	}
}
