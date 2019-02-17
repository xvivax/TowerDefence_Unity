using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private int indexToMove;

    public GameObject pathPoints;
    public int speed;

    private void Start()
    {
        indexToMove = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDir = pathPoints.transform.GetChild(indexToMove).position - transform.position;
        moveDir = moveDir.normalized;
        transform.position += moveDir * Time.deltaTime * speed;

        float dist = Vector3.Distance(pathPoints.transform.GetChild(indexToMove).position, transform.position);

        if (dist < 0.1f)
        {
            indexToMove++;
        }

        // If reaches END point
        if (indexToMove >= pathPoints.transform.childCount)
        {
            Spawner.enemyAmount--;
            Stats.lives--;
            Destroy(gameObject);
            return;
        }
    }
}
