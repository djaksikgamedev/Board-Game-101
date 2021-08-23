using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text woodText;
    public int wood;
    public Text meatText;
    public int meat;
    public Text warriorText;
    public int warrior;
    public Text turnText;
    public int turn;
    public Text roundText;
    public int rounds = 0;
    public Text questText;
    public int coins = 0;

    public GameObject endGamePanel;


    public static Manager instance;
    public int costInMeat = 2;
    public int costInWood = 1;
    private bool endGame = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        endGame = false;
        Time.timeScale = 1;
    }

    public void AddWood(int woodAmount)
    {
        wood += woodAmount;
        woodText.text = "Wood : " + wood;
    }
    public void AddMeat(int meatAmount)
    {
        meat += meatAmount;
        meatText.text = "Meat : " + meat;
    }

    public void AddTurn(int turnAmount)
    {
        turn += turnAmount;
        turnText.text = "Turn : " + turn;
        CheckIfEndRound();
        CheckIfEndGame();
    }

    public void AddWarrior(int warriorAmount)
    {
        warrior += warriorAmount;
        meat -= costInMeat;
        wood -= costInWood;
        woodText.text = "Wood : " + wood;
        meatText.text = "Meat : " + meat;
        warriorText.text = "Warriors : " + warrior;
    }

    public void Quest()
    {
        warrior--;
        warrior += Random.Range(0, 2);
        coins += Random.Range(0, 6);
        wood += Random.Range(0, 2);
        meat += Random.Range(0, 3);
        woodText.text = "Wood : " + wood;
        meatText.text = "Meat : " + meat;
        questText.text = "Coins : " + coins;
        warriorText.text = "Warriors : " + warrior;
    }

    private void CheckIfEndRound()
    {
        if (turn == 5)
        {
            turnText.text = "Press N for next round.";
        }
    }

    private void CheckIfEndGame()
    {
        if (rounds >= 8 && turn == 5)
        {
            endGame = true;
            Debug.Log("Game has ended.");
            turnText.text = "End game.";
            roundText.text = "End game.";
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (turn == 5 && Input.GetKeyDown(KeyCode.N) && endGame == false)
        {
            rounds++;
            turn = 0;
            turnText.text = "Turn : 0";
            roundText.text = "Round : " + rounds;
        }
    }
}