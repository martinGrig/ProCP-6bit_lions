using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarController : MonoBehaviour
{
    public List<GameObject> texts;
    private List<GameObject> temps;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        texts = new List<GameObject>();
        temps = new List<GameObject>();
    }

    public void UpdateList()
    {
        foreach (GameObject s in temps)
        {
            Destroy(s);
        }
        texts = new List<GameObject>();
        temps = new List<GameObject>();
        foreach (GameObject s in ShopSpawner.Instance.GetShops())
        {
            texts.Add(s);
        }
        for (int i = 0; i < texts.Count; i++)
        {
            temps.Add(Instantiate(prefab, gameObject.transform.position + new Vector3(180, i * -100f - 50f, 0), Quaternion.identity, gameObject.transform));
            
            Transform child = temps[i].transform.GetChild(1);
            child.GetComponent<TextMeshProUGUI>().text = texts[i].GetComponent<shopScript>().shopName;
            Transform button = temps[i].transform.GetChild(0);
            button.GetComponent<Button>().onClick.AddListener(texts[i].GetComponent<shopScript>().SwapClick);
        }
    }
}
