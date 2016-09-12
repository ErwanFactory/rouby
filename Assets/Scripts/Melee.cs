using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

    private float enemyForce;
    public float EnemyForce
    {
        get { return enemyForce; }
        set { enemyForce = value; }
    }

    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private int stopped;

	void Start () {
        speed = 1.0f;
        enemyForce = 0.01f;
        stopped = 0;
	}

    public void Stop()
    {
        stopped = 0;
    }

    public void Reprendre()
    {
        stopped = 1;
    }

    public void Avancer()
    {
        transform.position = (Vector2)transform.position + Vector2.up * speed * stopped;
    }

    public void Reculer()
    {
        transform.position = (Vector2)transform.position + Vector2.down * enemyForce * stopped;
    }
}
