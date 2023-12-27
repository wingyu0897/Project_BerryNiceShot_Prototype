using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit fruitPrefab;
	[SerializeField] private List<SpawnArea> spawns;
	[SerializeField] private float spawnTime;

	private float timer;

	private void Update()
	{
		if (timer <= 0)
		{
			SpawnArea spawn = spawns[Random.Range(0, spawns.Count)];
			timer = spawnTime;
			Fruit instance = Instantiate(fruitPrefab, spawn.GetPos(), Quaternion.identity);
			instance.GetComponent<Rigidbody2D>().AddForce(spawn.GetDirection() * 300f);
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}
}
