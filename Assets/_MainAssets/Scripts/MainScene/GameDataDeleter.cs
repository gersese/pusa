using UnityEngine;

public class GameDataDeleter : MonoBehaviour
{
	public void EraseGameData()
	{
		PlayerPrefs.DeleteAll();
	}
}

