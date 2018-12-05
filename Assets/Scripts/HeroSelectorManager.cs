using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectorManager : MonoBehaviour {

    public GameObject heroSelectUI;
    public GameObject elementSelectUI;
    public GameObject allSelectedHero;
    public GameObject startButton;
    public GameObject startUI;
    public GameObject nightUI;
    public GameObject playUI;

    private HeroChoice _heroSelected;
    private int nbHeroSelected;


    // Use this for initialization
    void Start () {
        heroSelectUI.SetActive(false);
        elementSelectUI.SetActive(false);
        nbHeroSelected = 0;
        startButton.gameObject.GetComponent<Button>().interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        nbHeroSelected = 0;

        foreach (Transform hero in allSelectedHero.gameObject.transform)
        {
            Debug.Log(hero.gameObject);
            if (hero.gameObject.GetComponent<HeroChoice>().Hero != null 
                && hero.gameObject.GetComponent<HeroChoice>().HeroElement != Element.None)
            {
                nbHeroSelected++;
            }
        }
        
        if (nbHeroSelected > 3)
            startButton.gameObject.GetComponent<Button>().interactable = true;
	}

    public void changeHero(GameObject buttonHero)
    {
        heroSelectUI.SetActive(true);
        elementSelectUI.SetActive(false);

        heroSelectUI.transform.position = buttonHero.transform.position;

        _heroSelected = buttonHero.transform.parent.gameObject.GetComponent<HeroChoice>();
    }

    public void changeElement(GameObject buttonElement)
    {
        heroSelectUI.SetActive(false);
        elementSelectUI.SetActive(true);

        elementSelectUI.transform.position = buttonElement.transform.position;

        _heroSelected = buttonElement.transform.parent.gameObject.GetComponent<HeroChoice>();
    }

    public void startGame()
    {
        heroSelectUI.SetActive(false);
        elementSelectUI.SetActive(false);
        startUI.SetActive(false);
        playUI.SetActive(true);
    }

    public void validerChangementHero(GameObject hero)
    {
        _heroSelected.GetComponent<HeroChoice>().Hero = Resources.Load<GameObject>("Units/" + hero.name);
        heroSelectUI.SetActive(false);

        _heroSelected.refreshUI();
    }

    public void validerChangementElement(GameObject element)
    {
        switch(element.name)
        {
            case "Fire" :
                _heroSelected.GetComponent<HeroChoice>().HeroElement = Element.Fire;
                break;
            case "Water":
                _heroSelected.GetComponent<HeroChoice>().HeroElement = Element.Water;
                break;
            case "Wind":
                _heroSelected.GetComponent<HeroChoice>().HeroElement = Element.Wind;
                break;
            case "Ground":
                _heroSelected.GetComponent<HeroChoice>().HeroElement = Element.Ground;
                break;
        }
        elementSelectUI.SetActive(false);

        _heroSelected.refreshUI();
    }

    public void nightStart()
    {
        playUI.SetActive(false);
        nightUI.SetActive(true);
    }
}
