using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {

	private GameSettings _settings;
	
	private  const float UPDATE_DELTA_TIME = 1f;

	private bool  _finish = false;
	private float _timer = 0;
	private float _lastTimeStep = 0f;

	public float Timer
	{
		get { return _timer; }
	}

	private void Awake()
	{
		_settings = App.Instance.Settings;
		_timer = _settings.GeneralSettings.GameLengthInSeconds;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_timer>0)
			_timer -= Time.deltaTime;
		else
		{
			if (!_finish)
			{
				_finish = true;
				_timer = 0;
				EventSystem.Send(new FinishTimerEvent());
			}
		}
		
		if (Time.time - _lastTimeStep >= UPDATE_DELTA_TIME)
		{
			_lastTimeStep = Time.time;
			EventSystem.Send(new TickTimerEvent(){ Time = _timer});
		}
	}
}
