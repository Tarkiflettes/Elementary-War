using Assets.Scripts.Data;
using UnityEngine;

public class SpriteList : MonoBehaviour
{
    public static SpriteList instance;

    public Sprite ARCHER;
    public Sprite MAGE;
    public Sprite TANK;
    public Sprite SWORDMAN;

    private static Sprite[] classSprite;
    //private static Animation[] classAnimMouvement;
    //private static Animation[] classAnimAttack;
    //private static Animator[] classAnim;

    void Start ()
    {
        instance = this;
        
        classSprite = new Sprite[] { ARCHER, MAGE, TANK, SWORDMAN };
        //classAnimMouvement = new Animation[] { ARCHERANIM_Movement, MAGEANIM_Movement, TANKANIM_Movement, SWORDMANANIM_Movement };
        //classAnimAttack = new Animation[] { ARCHERANIM_Attack, MAGEANIM_Attack, TANKANIM_Attack, SWORDMANANIM_Attack };
        //classAnim = new Animator[] { ARCHERANIM, MAGEANIM, TANKANIM, SWORDMANANIM };
        //animArcher.SetBool(canAttack, true);
    }

    public static Sprite getUnitSprite(Model model)
    {
        return classSprite[model.ModelClass.ClassId];
    }
}
