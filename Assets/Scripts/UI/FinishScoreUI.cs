using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FinishScoreUI : MonoBehaviour {
	
	private Text _text;
	private const string _textFormat = "Finish score = {0}";

	private void Awake()
	{
		_text = GetComponent<Text>();
	}

	// Use this for initialization
	void Start ()
	{
		_text.enabled = false;
		EventSystem.RegisterListener<FinishGameEvent>(HandleFinishGame);
	}
	
	private void HandleFinishGame(object obj)
	{
		var e = obj as FinishGameEvent;
		_text.enabled = true;
		_text.text = String.Format(_textFormat,e.FinishScore);
	}
}
