using UnityEngine;
using System.Collections;
using Assets.Scripts.Data;

public class UnityUnit : MonoBehaviour
{
    Animator anim;
    int canAttack = Animator.StringToHash("canAttack");
    int classeAnim = Animator.StringToHash("ClasseAnim");

    public AudioSource source;

    // water fire ground air

    public AudioClip archerWaterAttack;
    public AudioClip archerAirAttack;
    public AudioClip archerGroundAttack;
    public AudioClip archerFireAttack;

    public AudioClip swordmanWaterAttack;
    public AudioClip swordmanAirAttack;
    public AudioClip swordmanGroundAttack;
    public AudioClip swordmanFireAttack;

    public AudioClip tankWaterAttack;
    public AudioClip tankAirAttack;
    public AudioClip tankGroundAttack;
    public AudioClip tankFireAttack;

    public AudioClip mageWaterAttack;
    public AudioClip mageAirAttack;
    public AudioClip mageGroundAttack;
    public AudioClip mageFireAttack;

    public AudioClip archerDie;
    public AudioClip swordmanDie;
    public AudioClip tankDie;
    public AudioClip mageDie;

    public AudioClip invocation;

    private Rigidbody2D body;
    Vector2 pos;
	private bool someoneHere = false, stopMoving = false, die = false;
	private Unit differentUnit;
    private float cooldown = 0;

    public bool StopMoving
    {
        get
        {
            return stopMoving;
        }
        set
        {
            stopMoving = value;
        }
    }

    private float timer = -0.917f / 2;

    private Vector3 startPos;
    private bool start = true;

    private Unit unit;
    public Unit Unit
    {
        get
        {
            return unit;
        }
        set
        {
            unit = value;
        }
    }

	void Start ()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetInteger("ClasseAnim", unit.UnitModel.ModelClass.ClassId);
        
        //Debug.Log("classA" +anim.GetInteger(classeAnim));
        GetComponent<SpriteRenderer>().sprite = unit.UnitModel.UnitSprite;
        startPos = transform.position;
        //transform.position = new Vector3(startPos.x - (4 * (unit.Player.Side == Player.TeamSide.LEFT ? 1 : -1)), startPos.y, startPos.y);
        //Debug.Log(GetComponent<SpriteRenderer>().bounds);

        body = GetComponent<Rigidbody2D>();
        source.PlayOneShot(invocation, 5.0F);
    }
	
	void Update ()
    {
        if(cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }

        Player.TeamSide side = unit.Player.Side;
        if(timer >= 0)
        {
            if (start)
            {
                //tourne le sprite
                Vector3 theScale = transform.localScale;
                theScale.x *= side == Player.TeamSide.LEFT ? 1 : -1;
                transform.localScale = theScale;
                start = false;
                //anim.SetInteger(classeAnim, 1);
            }
            //Debug.Log("perso " + GetComponent<SpriteRenderer>().bounds);
            //transform.Translate(new Vector3(side == Player.TeamSide.LEFT ? 1 : -1, 0, 0) * Time.deltaTime);
            
            
        } else
        {
            //Debug.Log("ritu " + GetComponent<SpriteRenderer>().bounds);
            //transform.position = new Vector3(startPos.x + 1, startPos.y, startPos.y);
            timer += Time.deltaTime;
        }
            
	}

    void FixedUpdate()
    {

        if (!stopMoving)
        {
            body.velocity = new Vector2(unit.Player.Side == Player.TeamSide.LEFT ? 1 : -1, 0);
        }
        if (stopMoving)
        {
            //if (someoneHere) StartCoroutine(Disapear());
            if (someoneHere) StartCoroutine(Attaque(differentUnit));
            body.velocity = Vector2.zero;
        }

    }

    IEnumerator Attaque(Unit enemy)
    {
        yield return new WaitForSeconds(0);

        float addDegat = 0;
        float addDegatMagic = 0;

        /*
        if (enemy.Player.UnitList.Count>2)
        {
            if (enemy.Player.UnitList[1].UnitModel.ModelClass == UnitClass.ARCHER
                || enemy.Player.UnitList[1].UnitModel.ModelClass == UnitClass.MAGE)
            {
                addDegat += enemy.Player.UnitList[1].UnitModel.Stats.Attack;
                addDegatMagic += enemy.Player.UnitList[1].UnitModel.Stats.MagicAttack;
            }
        }

        if (enemy.Player.UnitList.Count > 3)
        {
            if (enemy.Player.UnitList[2].UnitModel.ModelClass == UnitClass.ARCHER)
            {
                addDegat += enemy.Player.UnitList[2].UnitModel.Stats.Attack;
                addDegatMagic += enemy.Player.UnitList[2].UnitModel.Stats.MagicAttack;
            }
        }
        */

        if (cooldown <= 0)
        {
            cooldown = 1;
            Debug.Log(Unit.HP + " - " + Unit.Player.Side);
            sound(0, Unit.UnitModel.ModelClass.ClassId, Unit.UnitModel.ModelElement.ElementId);

            

            if ((enemy.UnitModel.Stats.Attack - Unit.UnitModel.Stats.Defense) > 0)
            {
                Unit.HP -= (enemy.UnitModel.Stats.Attack+addDegat - Unit.UnitModel.Stats.Defense);
                Debug.Log("y a taper et calcul = "+ enemy.UnitModel.Stats.Attack+" - "+ Unit.UnitModel.Stats.Defense);

            }

            if ((enemy.UnitModel.Stats.MagicAttack - Unit.UnitModel.Stats.MagicDefense) > 0)
            {
                Unit.HP -= (enemy.UnitModel.Stats.MagicAttack + addDegatMagic - Unit.UnitModel.Stats.MagicDefense);
                Debug.Log("y a magie  et calcul = " + enemy.UnitModel.Stats.MagicAttack + " - " + Unit.UnitModel.Stats.MagicDefense);
            }


            //new WaitForSeconds(1);
            /*while (Unit.HP>0)
            {
                //Debug.Log(Unit.HP);
                Unit.HP -= enemy.UnitModel.Stats.Attack - Unit.UnitModel.Stats.Defense + enemy.UnitModel.Stats.MagicAttack - Unit.UnitModel.Stats.MagicDefense;
                new WaitForSeconds(1);
            }*/

            if (Unit.HP <= 0)
            {
                StartCoroutine(Disapear());
            }
        }
    }



    void sound(int ad, int unitclass, int Element)
    {
        if (ad == 0)
        {
            switch (unitclass)
            {
                case 0: // archer
                    switch (Element)
                    {
                        case 0: // fire
                            source.PlayOneShot(archerFireAttack, 2.0f);
                            break;
                        case 1: // water
                            source.PlayOneShot(archerWaterAttack, 2.0f);
                            break;
                        case 2: // ground
                            source.PlayOneShot(archerGroundAttack, 2.0f);
                            break;
                        case 3: // air
                            source.PlayOneShot(archerAirAttack, 2.0f);
                            break;
                    }
                    break;
                case 1: // mage
                    switch (Element)
                    {
                        case 0:
                            source.PlayOneShot(mageFireAttack, 2.0f);
                            break;
                        case 1:
                            source.PlayOneShot(mageWaterAttack, 2.0f);
                            break;
                        case 2:
                            source.PlayOneShot(mageGroundAttack, 2.0f);
                            break;
                        case 3:
                            source.PlayOneShot(mageAirAttack, 2.0f);
                            break;
                    }
                    break;
                case 2: // tank
                    switch (Element)
                    {
                        case 0:
                            source.PlayOneShot(tankFireAttack, 2.0f);
                            break;
                        case 1:
                            source.PlayOneShot(tankWaterAttack, 2.0f);
                            break;
                        case 2:
                            source.PlayOneShot(tankGroundAttack, 2.0f);
                            break;
                        case 3:
                            source.PlayOneShot(tankAirAttack, 2.0f);
                            break;
                    }
                    break;
                case 3: // swordman
                    switch (Element)
                    {
                        case 0:
                            source.PlayOneShot(swordmanFireAttack, 2.0f);
                            break;
                        case 1:
                            source.PlayOneShot(swordmanWaterAttack, 2.0f);
                            break;
                        case 2:
                            source.PlayOneShot(swordmanGroundAttack, 2.0f);
                            break;
                        case 3:
                            source.PlayOneShot(swordmanAirAttack, 2.0f);
                            break;
                    }
                    break;
            }
        }
        else
        {
            switch (unitclass)
            {
                case 0: // archer
                    source.PlayOneShot(archerDie, 1.0F);
                    break;
                case 1: // mage
                    source.PlayOneShot(mageDie, 1.0F);
                    break;
                case 2: // tank
                    source.PlayOneShot(tankDie, 1.0F);
                    break;
                case 3: // swordman
                    source.PlayOneShot(swordmanDie, 1.0F);
                    break;
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        UnityUnit uunit = go.GetComponent<UnityUnit>();
        differentUnit = uunit.Unit;

        if (unit.isEnemyWith(differentUnit))
        {
            someoneHere = true;
            stopMoving = true;
        }
        if (uunit.StopMoving)
        {
            stopMoving = true;
        }


		// mdr c importen -- > differentUnit.UnitModel.ModelClass == UnitClass.ARCHER;






    }

	void OnTriggerStay2D (Collider2D other){

	}

    void OnTriggerExit2D()
    {
        Debug.Log("Exit");
        stopMoving = false;
        body.AddForce(new Vector2(unit.Player.Side == Player.TeamSide.LEFT ? 1 : -1, 0) * 2500 * Time.deltaTime);
    }
		

    IEnumerator Disapear()
    {
        //yield return new WaitForSeconds(3);
        sound(1, Unit.UnitModel.ModelClass.ClassId, Unit.UnitModel.ModelElement.ElementId);
        Debug.Log("disapear");
        body.transform.position = new Vector2(0, 20);
        Destroy(this.gameObject, 1);
        yield return new WaitForSeconds(0);
    }
}
