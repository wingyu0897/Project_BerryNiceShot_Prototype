using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	[SerializeField] private GameObject projectile;

	private Collider2D col;

	private void Awake()
	{
		col = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("Arrow")) return;
		col.enabled = false;
		GetComponent<Rigidbody2D>().gravityScale = 2f;
		GameObject instance = Instantiate(projectile, transform);
		instance.transform.position = collision.transform.position;
		instance.transform.rotation = collision.transform.rotation;
		Destroy(gameObject, 3f);
	}
}
