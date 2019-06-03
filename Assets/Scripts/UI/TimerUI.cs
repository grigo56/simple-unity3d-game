using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerUI : MonoBehaviour
{

	
	private Text _text;
	private const string _textFormat = "Timer = {0}";
	
	private void Awake()
	{
		_text = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		EventSystem.RegisterListener<TickTimerEvent>(HandleChangeTimer);
	}

	private void HandleChangeTimer(object obj)
	{
		var e = obj as TickTimerEvent;
		var str = String.Format(_textFormat,(int)e.Time);
		_text.text = str;
	}
}
