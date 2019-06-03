using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleEntity))]
public class MoveHandler : MonoBehaviour
{
	private GameSettings _setting;
	private TimerManager _timer;
	private CircleEntity _circle;

	private float _sizeSpeedMod = 1f;
	
	void Awake()
	{
		_setting = App.Instance.Settings;
		_timer 	 = App.Instance.TimerManager;
		_circle = GetComponent<CircleEntity>();
	}

	void Start()
	{
		_sizeSpeedMod = CallculateSizeSpeedModificator();
	}
	
	private float CallculateTimeSpeedModificator()
	{
		var allTime 	= _setting.GeneralSettings.GameLengthInSeconds;
		var currentTime = _timer.Timer;
		var speedStart 	= _setting.GeneralSettings.StartWorldSpeed;
		var speedEnd 	= _setting.GeneralSettings.EndWorldSpeed;
		return Mathf.Lerp(speedStart, speedEnd, 1 - currentTime / allTime);
	}
	
	private float CallculateSizeSpeedModificator()
	{
		var maxSpawnSpeed 	= _setting.SpawnSetting.MaxSpawnSpeed;
		var minSpawnSpeed 	= _setting.SpawnSetting.MinSpawnSpeed;
		var sizeRange = _setting.SpawnSetting.MaxSpawnSize - _setting.SpawnSetting.MinSpawnSize;
		return Mathf.Lerp(minSpawnSpeed, maxSpawnSpeed, 1 - _circle.Size / sizeRange);
	}
	
	void Update () {
		transform.position +=  Vector3.up * _sizeSpeedMod * Time.deltaTime * CallculateTimeSpeedModificator();
	}
}
