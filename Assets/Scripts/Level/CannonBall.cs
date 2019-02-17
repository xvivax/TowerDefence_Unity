using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public float CannonSpeed;
    public int DamageToDo = 30;

    private Transform target;

    public void SearchEnemy(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (GameManager.isGamePaused)
        {
            return;
        }

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;

        transform.position += dir * Time.deltaTime * CannonSpeed;

        if (dir.magnitude < Time.deltaTime * CannonSpeed)
        {
            DamageTarget(target);
            Destroy(gameObject);
        }
    }

    void DamageTarget(Transform _enemy)
    {
        Enemy enemy = _enemy.GetComponent<Enemy>();
        enemy.TakeDamage(DamageToDo);
    }


}
