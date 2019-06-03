using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoSingleton<App>
{
	[SerializeField] private GameSettings _gameSettings;
	private TimerManager _timerManager;
	
	public TimerManager TimerManager
	{
		get { return _timerManager; }
	}

	public GameSettings Settings
	{
		get { return _gameSettings; }
	}

	// Use this for initialization
	void Start ()
	{
		InitAllSystems();
	}

	private void InitAllSystems()
	{
		gameObject.AddComponent<SpawnManager>();
		gameObject.AddComponent<ScoreManager>();
		_timerManager = gameObject.AddComponent<TimerManager>();
	}
}
