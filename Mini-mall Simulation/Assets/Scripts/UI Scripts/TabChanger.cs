using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabChanger : MonoBehaviour
{

    List<GameObject> Buttons;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        Buttons = GetButtons();
        //Find the first button and colour it properly
        GameObject firstButton = Buttons[0];
        firstButton.GetComponent<Image>().color = new Color(0.533f, 0.533f, 0.533f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonPainter(GameObject button)
    {
        foreach (GameObject b in Buttons)
        {

            if (b != button)
            {
                b.GetComponent<Image>().color = new Color(0.400f, 0.400f, 0.400f);
            }
            else if (b == button)
            {
                b.GetComponent<Image>().color = new Color(0.533f, 0.533f, 0.533f);
            }
        }
    }


    public List<GameObject> GetButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        int childCount = parent.childCount;
        for (int i = 0; i < childCount/2; i++)
        {
            GameObject childSelected = parent.GetChild(i).gameObject;
            buttons.Add(childSelected);
        }
        return buttons;
    }
}
