using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	
	[SerializeField] protected GameObject spawnPoint;
	[SerializeField] protected GameObject[] enemies;
	[SerializeField] protected int maxEnemiesOnScreen;
	[SerializeField] protected int totalEnemies;
	[SerializeField] protected int enemiesPerSpawn;

	private int enemiesOnScreen = 0;

	const float spawnDelay = 0.5f;

	
	void Start()
    {
		StartCoroutine(Spawn());
    }
	public void removeEnemyFromScreen()
    {
		if (enemiesOnScreen > 0)
        {
			enemiesOnScreen--;
        }
    }

	IEnumerator Spawn()
    {
		if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
		{
			for (int i = 0; i < enemiesPerSpawn; i++)
			{
				if (enemiesOnScreen < maxEnemiesOnScreen)
				{
					GameObject newEnemy = Instantiate(enemies[2]) as GameObject;
					newEnemy.transform.position = spawnPoint.transform.position;
					enemiesOnScreen++;
				}
			}
			yield return new WaitForSeconds(spawnDelay);
			StartCoroutine(Spawn());
		}
	}
}
