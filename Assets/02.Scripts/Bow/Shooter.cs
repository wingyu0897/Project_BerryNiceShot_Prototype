using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
	[SerializeField] private float power;

    public void Shoot(Vector2 dir, float powerPercentage = 1.0f)
	{
		Projectile instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		instance.Shoot(dir, power * powerPercentage);
	}
}
