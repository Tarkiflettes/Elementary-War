using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    private UnitStats unit;
    private UnitStats enemyUnit;
    private Animator animController;
    private bool canMove = true;
    private bool canAttack = false;

    // Use this for initialization
    void Start () {
        unit = this.gameObject.GetComponent<UnitStats>();
        animController = this.gameObject.GetComponent<Animator>();

        if (unit.sendByPlayer)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!animController.GetBool("Die") && !animController.GetBool("CanAttack") && canMove && !canAttack)
        {
            if (unit.sendByPlayer)
            {
                this.gameObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            }
            else
            {
                this.gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
            }

        }
        else if (canAttack && !animController.GetBool("Die"))
        {
            if (enemyUnit.isAlive)
                animController.SetBool("CanAttack", true);
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        float maPos;
        float collisionPos;
        float distance;
        
        if (collision.gameObject.tag == "Unit")
        {
            maPos = this.gameObject.transform.position.x;
            collisionPos = collision.gameObject.transform.position.x;

            if (unit.sendByPlayer)
            {
                if (collision.GetComponent<UnitStats>().sendByPlayer)
                {
                    
                    if (maPos + 2 > collisionPos && maPos < collisionPos)
                        canMove = false;
                }
                else
                {
                    distance = (float)(maPos + ((unit.attackDistance * 1.5 + 2) * this.gameObject.transform.localScale.x));
                    if (distance > collisionPos && enemyUnit == null)
                    {
                        canMove = false;
                        canAttack = true;
                        enemyUnit = collision.GetComponent<UnitStats>();
                    }
                }
            }
            else
            {
                if (collision.GetComponent<UnitStats>().sendByPlayer)
                {
                    distance = (float)(maPos + ((unit.attackDistance * 1.5 + 2) * this.gameObject.transform.localScale.x));
                    if (distance < collisionPos && enemyUnit == null)
                    {
                        canMove = false;
                        canAttack = true;
                        enemyUnit = collision.GetComponent<UnitStats>();
                    }
                }
                else
                {
                    if (maPos - 2 < collisionPos && maPos > collisionPos)
                        canMove = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            canMove = true;
            canAttack = false;
            if (collision.GetComponent<UnitStats>().sendByPlayer != unit.sendByPlayer)
            {
                animController.SetBool("CanAttack", false);
            }
        }
    }

    public void unitAttack()
    {
        enemyUnit.life -= unit.attack;
        if (enemyUnit.life <= 0)
        {
            enemyUnit.Die();
            animController.SetBool("CanAttack", false);
        }
    }
}
