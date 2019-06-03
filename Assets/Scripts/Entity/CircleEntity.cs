using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEntity : MonoBehaviour
{

	private float _size;

	public float Size
	{
		get { return _size; }
	}


	public void Init(Vector3 position, float size,Color color)
	{
		_size = size;
		
		transform.position = position;
		
		transform.localScale = new Vector3(size,size,1);
		GetComponent<SpriteRenderer>().color = color;
		
		gameObject.AddComponent<MoveHandler>();
		gameObject.AddComponent<ClickHandler>();
		gameObject.AddComponent<DeathHandler>();
	}
}
