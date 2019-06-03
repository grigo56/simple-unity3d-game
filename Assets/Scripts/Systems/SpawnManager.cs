using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private GameSettings _settings;

	private Transform _world;
	private float _lastTimeStep = 0f;
	private bool  _enable = true;

	private void Awake()
	{
	    Debug.Log("Start");
		_settings = App.Instance.Settings;
	}
	
	// Use this for initialization
	void Start () {
		EventSystem.RegisterListener<FinishGameEvent>(HandleFinishGame);
		_world = new GameObject().transform ;
		_world.transform.name = "World";
	}
	
	private void HandleFinishGame(object obj)
	{
		_enable = false;
	}

	
	// Update is called once per frame
	void Update ()
	{
		if (!_enable) return;
		
		if (Time.time - _lastTimeStep >= _settings.SpawnSetting.SpawnRateInSeconds)
		{
			_lastTimeStep = Time.time;
			SpawnCircle();
		}
	}
	
	private void SpawnCircle()
	{
		var position	= Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f,0.9f),-0.3f,10));
		var size		= Random.Range(_settings.SpawnSetting.MinSpawnSize, _settings.SpawnSetting.MaxSpawnSize);
		var color 		= _settings.SpawnSetting.ColorsPalette[Random.Range(0,_settings.SpawnSetting.ColorsPalette.Length)];

		var go 	 = GameObject.Instantiate(_settings.SpawnSetting.SpawnPrefab, _world.transform, true);
		var entity = go.AddComponent<CircleEntity>();
		entity.Init(position,size,color);
	}
}
