using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
	private Text _text;
	private const string _textFormat = "Score = {0}";
	
	private void Awake()
	{
		_text = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		EventSystem.RegisterListener<ChangeScoreEvent>(HandleChangeScore);
	}

	private void HandleChangeScore(object obj)
	{
		var e = obj as ChangeScoreEvent;
		_text.text = String.Format(_textFormat,e.NewScore);
	}
}
