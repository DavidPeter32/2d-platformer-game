using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManaManager : MonoBehaviour
{
    private static int health = 5;
    private static int mana = 10;
    public Slider HealthBar;
    public Slider ManaBar;

    public static int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public static int Mana
    {
        get
        {
            return mana;
        }
        set
        {
           mana = value;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = health;
        ManaBar.value = mana;
    }
     
    
    
}
