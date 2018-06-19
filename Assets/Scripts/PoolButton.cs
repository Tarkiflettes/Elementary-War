using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PoolButton : MonoBehaviour
{
    public GameObject gc;
    public int slotId;

    private GameController gameController;

    void Start()
    {
        gameController = gc.GetComponent<GameController>();
    }

    public void handleClick()
    {
        gameController.Player1.spawnUnit(slotId);

    }
}
