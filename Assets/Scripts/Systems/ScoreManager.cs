using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private GameSettings _settings;
	private float _score = 0f;
	private bool _finishGame = false;

	private void Awake()
	{
		_settings = App.Instance.Settings;
	}

	// Use this for initialization
	void Start () {
		EventSystem.RegisterListener<ClickOnCircleEvent>(HandleCircleClicked);
		EventSystem.RegisterListener<FinishTimerEvent>(HandleFinishTimer);
	}

	private float CalculateScoreForCircleSize(float size)
	{
		var minScore = _settings.GeneralSettings.MinClickScore;
		var maxScore = _settings.GeneralSettings.MaxClickScore;
		var minSize  = _settings.SpawnSetting.MinSpawnSize;
		var maxSize = _settings.SpawnSetting.MaxSpawnSize;
		return Mathf.Lerp(minScore,maxScore,1-size/(maxSize-minSize));
	}

	private void HandleFinishTimer(object obj)
	{
		var e = obj as FinishTimerEvent;
		EventSystem.Send(new FinishGameEvent(){FinishScore = _score });
		_finishGame = true;
	}
	
	private void HandleCircleClicked(object obj)
	{
		if (_finishGame)
			return;
		
		var e = obj as ClickOnCircleEvent;
		var newScore = CalculateScoreForCircleSize(e.CircleSize);
		_score += (int)newScore;
		EventSystem.Send(new ChangeScoreEvent(){NewScore = _score});
	}
}
