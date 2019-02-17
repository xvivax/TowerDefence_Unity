using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightShip : MonoBehaviour {

    [Header("Necessary Stuff")]
    public Transform PartToRotate;
    public Transform ShootPart;
    public GameObject cannonBallPref;

    [Header("Ship settings")]
    public float range;
    public float fireRate;
    private float fireCountdown;

    private float lowestDist;
    private Transform target = null;
    private float rotspeed = 10;

    void Start ()
    {
        fireCountdown = 1f/  fireRate;

        InvokeRepeating("FollowEnemy", 0f, 0.5f);
    }

    void FollowEnemy()
    {
        if (Enemy.AllEnemies == null)
        {
            return;
        }

        lowestDist = Mathf.Infinity;
        Transform enemyToFollow = null; 

        foreach (Enemy enemy in Enemy.AllEnemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);

            if (dist < lowestDist && dist <= range)
            {               
                lowestDist = dist;
                enemyToFollow = enemy.transform;
            }
        }

        if (enemyToFollow != null)
        {
            target = enemyToFollow;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (GameManager.isGamePaused)
        {
            return;
        }

        if (target != null)
        {
            TurnToEnemy();

            if (fireCountdown <= 0)
            {
                Shot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
            
        }     
    }

    void TurnToEnemy()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * rotspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0.0f, rot.y, 0.0f);
    }

    void Shot()
    {
        GameObject InstCannon = Instantiate(cannonBallPref, ShootPart.transform.position, Quaternion.identity) as GameObject;

        CannonBall cannonScrpt = InstCannon.GetComponent<CannonBall>();

        if (cannonScrpt != null)
        {
            cannonScrpt.SearchEnemy(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
