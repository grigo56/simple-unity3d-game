using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnSetting
{
	[SerializeField]
	[Range(0.01f, 99f)]
	private float _spawnRateInSeconds = 1;
	[Range(0.1f, 0.8f)]
	[SerializeField] private float 	_minSpawnSize = 0.2f;
	[Range(0.1f, 0.8f)]
	[SerializeField] private float 	_maxSpawnSize = 0.8f;
	[Range(1f, 10f)]
	[SerializeField] private float 	_minSpawnSpeed = 0.2f;
	[Range(1f, 10f)]
	[SerializeField] private float 	_maxSpawnSpeed = 0.8f;
	[SerializeField] private GameObject _spawnPrefab;
	[SerializeField] private Color[] _colorsPalette;
	
	public float MinSpawnSize
	{
		get { return _minSpawnSize; }
	}
	
	public float MaxSpawnSize
	{
		get { return _maxSpawnSize; }
	}
	
	
	public float SpawnRateInSeconds
	{
		get { return _spawnRateInSeconds; }
	}

	
	public GameObject SpawnPrefab
	{
		get { return _spawnPrefab; }
	}

	
	
	public Color[] ColorsPalette
	{
		get { return _colorsPalette; }
	}

	public float MinSpawnSpeed
	{
		get { return _minSpawnSpeed; }
	}

	public float MaxSpawnSpeed
	{
		get { return _maxSpawnSpeed; }
	}
}

[Serializable]
public class SoundSettings
{
	[SerializeField] private SoundArray _bubbleClick;
	[SerializeField] private SoundArray _winGame;
	[Range(0f, 1f)]
	[SerializeField] private float _volumeFactor;
	public SoundArray BubbleClick
	{
		get { return _bubbleClick; }
	}

	public float VolumeFactor
	{
		get { return _volumeFactor; }
	}

	public SoundArray WinGame
	{
		get { return _winGame; }
	}
}

[Serializable]
public class GeneralSettings
{
	[SerializeField]
	[Range(1f, 99f)]
	private float 	_startWorldSpeed = 1;
	[SerializeField]
	[Range(1f, 99f)]
	private float 	_endWorldSpeed 	 = 1;
	[SerializeField]
	[Range(1f, 99f)]
	private int 	_minClickScore = 1;
	[SerializeField]
	[Range(1f, 99f)]
	private int 	_maxClickScore = 1;
	[SerializeField]
	[Range(1f, 99f)]
	private float 	_gameLengthInSeconds = 10;
	
	public int MinClickScore
	{
		get { return _minClickScore; }
	}
	
	public float GameLengthInSeconds
	{
		get { return _gameLengthInSeconds; }
	}

	public float StartWorldSpeed
	{
		get { return _startWorldSpeed; }
	}

	public float EndWorldSpeed
	{
		get { return _endWorldSpeed; }
	}

	public int MaxClickScore
	{
		get { return _maxClickScore; }
	}
}

[CreateAssetMenu(menuName = "GameSetting")]
public class GameSettings : ScriptableObject
{
	public SpawnSetting SpawnSetting;
	public SoundSettings SoundSettings;
	public GeneralSettings  GeneralSettings;
}
