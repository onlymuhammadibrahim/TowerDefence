using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] protected int target = 0;
	[SerializeField] protected Transform exitPoint;
	[SerializeField] protected Transform[] wayPoints;
	[SerializeField] protected float navigationUpdate;          //update time delta and move towards

	private Transform enemy;
	private float navigatonTime = 0;


	// Use this for initialization
	void Start () {
		enemy = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (wayPoints != null)
        {
			navigatonTime += Time.deltaTime;
			if (navigatonTime > navigationUpdate)
            {
				if(target< wayPoints.Length)
                {
					enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navigatonTime);
                }
                else
                {
					enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigatonTime);
                }
				navigatonTime = 0;
            }
        }

	
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Checkpoint")
        {
			target++;
        }
		else if(other.tag == "Finish")
        {
			GameManager.instance.removeEnemyFromScreen();
			Destroy(gameObject);
        }
    }
}
