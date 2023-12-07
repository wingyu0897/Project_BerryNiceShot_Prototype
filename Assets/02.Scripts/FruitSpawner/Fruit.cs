using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	private Collider2D col;

	private void Awake()
	{
		col = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		col.enabled = false;
		GetComponent<Rigidbody2D>().gravityScale = 2f;
		Destroy(gameObject, 3f);
	}
}
