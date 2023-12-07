using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private Vector2 area;
	[Range(-180, 180)]
	[SerializeField] private float minAngle;
	[Range(-180, 180)]
	[SerializeField] private float maxAngle;

	public Vector2 GetPos()
	{
		float x = Random.Range(transform.position.x - area.x / 2f, transform.position.x + area.x / 2f);
		float y = Random.Range(transform.position.y - area.y / 2f, transform.position.y + area.y / 2f);
		Vector2 pos = new Vector2(x, y);
		return pos;
	}

	public Vector2 GetDirection()
	{
		float rad = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;
		float x = Mathf.Cos(rad);
		float y = Mathf.Sin(rad);
		Vector2 dir = new Vector2(x, y);
		return dir;
	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(transform.position, area);
		Gizmos.color = Color.white;
	}
#endif
}
