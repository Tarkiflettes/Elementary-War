﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Element { None, Fire, Water, Wind, Ground }

public class UnitStats : MonoBehaviour {

    public bool sendByPlayer;
    public bool isAlive = true;

    public int life;
    public int attack;
    public int attackDistance;
    public Element currentElement;

    private Animator animController;

	// Use this for initialization
	void Start () {
        animController = this.gameObject.GetComponent<Animator>();
        currentElement = Element.Fire;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Die()
    {
        isAlive = false;
        animController.SetBool("Die", true);
        Invoke("delete", 0.75f);

        foreach(Collider2D col in this.GetComponents<Collider2D>())
        {
            col.enabled = false;
        }

    }

    private void delete()
    {
        Destroy(this.gameObject);
    }

}
