using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Image healthBar;

	public static List<Enemy> AllEnemies { get; set; }
    public float health;

    public GameObject PopupMoneyPref;

    private float startHealth;
    private int worth;
    private Spawner spawner;

    private void OnEnable()
    {
        if (AllEnemies == null)
        {
            AllEnemies = new List<Enemy>();
        }
        AllEnemies.Add(this);
    }
    private void OnDisable()
    {
        AllEnemies.Remove(this);
    }

    private void Start()
    {
        startHealth = health;

        spawner = FindObjectOfType<Spawner>();
        worth = spawner.GetEnemyWorth();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        Die();
    }

    private void Die()
    {
        if (health <= 0)
        {
            InstPopUpMoney();
            Spawner.enemyAmount--;
            Stats.money += worth;
            Destroy(gameObject);
        }
    }

    void InstPopUpMoney()
    {
        GameObject temp = Instantiate(PopupMoneyPref, transform.position, Quaternion.identity);
        Destroy(temp, 1f);
    }
}
