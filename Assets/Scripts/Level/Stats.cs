using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public static int money;
    public static int lives;
    public static int wave;

    public Text moneyText;
    public int startMoney;

    public Text livesText;
    public int startLives;

    void Start()
    {
        money = startMoney;
        lives = startLives;
        wave = 0;
    }

    void Update()
    {
        UpdateMoney();
        UpdateLives();
    }

    private void UpdateMoney()
    {
        if (money <= 0)
        {
            moneyText.text = "$0";
            return;
        }

        moneyText.text = "$" + money;
    }

    private void UpdateLives()
    {
        if (lives == 1)
        {
            livesText.text = lives + " LIVE";
            return;
        }
        livesText.text = lives + " LIVES";
    }
}
