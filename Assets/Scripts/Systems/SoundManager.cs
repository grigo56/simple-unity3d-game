using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	private GameSettings _settings;
	private AudioSource _source;

	private void Awake()
	{
		_settings = App.Instance.Settings;
		_source  = gameObject.AddComponent<AudioSource>();
	}

	// Use this for initialization
	void Start()
	{
		EventSystem.RegisterListener<ClickOnCircleEvent>(HandleCircleClicked);
		EventSystem.RegisterListener<FinishGameEvent>(HandleFinishGame);
	}

	private void HandleFinishGame(object obj)
	{
		_settings.SoundSettings.WinGame.PlaySound(_source);
	}


	private void HandleCircleClicked(object obj)
	{
		_settings.SoundSettings.BubbleClick.PlaySound(_source);
	}
}
