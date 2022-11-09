using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int selectedWeapon = 0;
    [SerializeField] GameObject Weapon1;
    [SerializeField] GameObject Weapon2;
    // Start is called before the first frame update
    void Start()
    { 
        SetWeapon();
    }

    public void SelectWeapon()
    {
       if (selectedWeapon == 0)
        {
            selectedWeapon = 1;
            Debug.Log("Changed to Rifle");
        }
        else
        {
            selectedWeapon = 0;
            Debug.Log("Changed to Revolver");
        }
        SetWeapon();
    }

    void SetWeapon()
    {
        switch (selectedWeapon)
        {
            case 0:
                Weapon1.SetActive(true);
                Weapon2.SetActive(false);
                break;
            case 1:
                Weapon1.SetActive(false);
                Weapon2.SetActive(true);
                break;

        }
    }
}
