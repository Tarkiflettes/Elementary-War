using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;
using Assets.Scripts.Logic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject unityUnit;
    public Text timerText;

    private Player player1;
    public Player Player1
    {
        get
        {
            return player1;
        }
    }
    private Player player2;
    public Player Player2
    {
        get
        {
            return player2;
        }
    }

    private int gameTime;

    private float gameDeltaTimer;
    private float AITickDelay;

	void Start ()
    {
        instance = this;
        player1 = new Player(Player.TeamSide.LEFT);
        player2 = new AI(AI.Difficulty.NORMAL , Player.TeamSide.RIGHT);

        player1.Pool = new Pool(new Model[] { new Model(UnitClass.ARCHER, 1, Element.AIR, 1), new Model(UnitClass.TANK, 1, Element.WATER, 1), new Model(UnitClass.MAGE, 1, Element.GROUND, 1), new Model(UnitClass.SWORDMAN, 1, Element.FIRE, 1) });
        player2.Pool = new Pool(new Model[] { new Model(UnitClass.ARCHER, 1, Element.AIR, 1), new Model(UnitClass.TANK, 1, Element.WATER, 1), new Model(UnitClass.MAGE, 1, Element.GROUND, 1), new Model(UnitClass.SWORDMAN, 1, Element.FIRE, 1) });

        gameDeltaTimer = 1;
        AITickDelay = 4;//Two second
    }
	
	void Update ()
    {
        gameDeltaTimer -= Time.deltaTime;

        if(gameDeltaTimer <= 0)
        {
            gameTime++;
            int minutes = gameTime / 60;
            int seconds = gameTime % 60;
            timerText.text = (minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + " : " + (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
            gameDeltaTimer = 1;
        }

	    if(player2 is AI)
        {
            AI ai = (AI) player2;
            AITickDelay -= Time.deltaTime;

            if (AITickDelay <= 0)
            {
                ai.tickAI();
                AITickDelay = 4;
            }
        }
	}
}
