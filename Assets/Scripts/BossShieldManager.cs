using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldManager : MonoBehaviour
{
    public List<GameObject> shieldPanels;
    public List<ShieldType> shieldPanelTypes;
    [SerializeField] private GameObject shieldParent;
    public Material redMaterial;
    public Material blueMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Store child panels in list
        foreach (Transform child in shieldParent.transform)
        {
            shieldPanels.Add(child.gameObject);
            Debug.Log("Added");
        }

        // Generate 4 random shield types
        for (int i = 0; i < 4; i++)
        {
            shieldPanelTypes.Add((ShieldType)Random.Range(0, 2));
            Debug.Log("Shield " + i + " Type: " + shieldPanelTypes[i]);
        }

        // Change colors of panels
        for(int i = 0; i < shieldPanels.Count; i++)
        {
            if(shieldPanelTypes[i] == ShieldType.RED)
            {
                shieldPanels[i].GetComponent<Renderer>().material = redMaterial;
                shieldPanels[i].tag = "RedEnemy"; // Change tag of panel
            }
            else if (shieldPanelTypes[i] == ShieldType.BLUE)
            {
                shieldPanels[i].GetComponent<Renderer>().material = blueMaterial;
                shieldPanels[i].tag = "BlueEnemy"; // Change tag of panel
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsChildrenActive()
    {
        for (int i = 0; i < shieldPanels.Count; i++)
        {
            if (shieldPanels[i].activeInHierarchy)
                return true;
        }

        return false;
    }
}
