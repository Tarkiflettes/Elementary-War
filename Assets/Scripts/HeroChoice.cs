using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroChoice : MonoBehaviour { 

    private GameObject _heroSelected;
    private Element _elementSelected;

    public Sprite[] HeroSprite;
    public Sprite[] ElementSprite;

    // Use this for initialization
    void Start() {
        _elementSelected = Element.None;
    }

    // Update is called once per frame
    void Update() {

    }

    public GameObject Hero
    {
        get { return _heroSelected; }
        set
        {
            _heroSelected = value;
        }
    }

    public Element HeroElement
    {
        get { return _elementSelected; }
        set
        {
            _elementSelected = value;
        }
    }

    public void refreshUI()
    {
        if (_heroSelected.name != null)
        {
            switch (_heroSelected.name)
            {
                case "ArcherUnit":
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = HeroSprite[0];
                    break;

                case "EpeisteUnit":
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = HeroSprite[1];
                    break;

                case "MageUnit":
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = HeroSprite[2];
                    break;

                case "TemplierUnit":
                    this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = HeroSprite[3];
                    break;
            }
        }

        switch (_elementSelected)
        {
            case Element.Fire:
                this.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = ElementSprite[0];
                break;

            case Element.Water:
                this.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = ElementSprite[1];
                break;

            case Element.Wind:
                this.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = ElementSprite[2];
                break;

            case Element.Ground:
                this.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = ElementSprite[3];
                break;
        }
    }
}
