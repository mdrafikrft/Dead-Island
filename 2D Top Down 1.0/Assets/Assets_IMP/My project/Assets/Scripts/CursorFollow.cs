using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{

	private void Start()
	{
		Cursor.visible = false;
	}
	private void Update()
	{
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector2.MoveTowards(transform.position, cursorPos, 100 * Time.deltaTime);
	}
}
