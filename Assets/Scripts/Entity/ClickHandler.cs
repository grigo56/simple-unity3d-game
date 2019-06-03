using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleEntity))]
public class ClickHandler : MonoBehaviour
{

	private CircleEntity _circle;
	private GameSettings _setting;

	private void Awake()
	{
		_circle = GetComponent<CircleEntity>();
		_setting = App.Instance.Settings;
	}

	// Use this for initialization
	private void OnMouseDown()
	{
		EventSystem.Send(new ClickOnCircleEvent(){CircleSize = _circle.Size});
		
		Destroy(gameObject);
	}
}
