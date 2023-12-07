using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigid;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	public void Shoot(Vector2 dir, float power)
	{
		Vector2 force = dir.normalized * power;
		rigid.AddForce(force, ForceMode2D.Impulse);
	}

	private void FixedUpdate()
	{
		Vector2 velocity = rigid.velocity;
		float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.attachedRigidbody.AddForceAtPosition(rigid.velocity * 0.4f, transform.position, ForceMode2D.Impulse);

		Destroy(gameObject);
	}
}
