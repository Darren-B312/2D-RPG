using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterSheet : MonoBehaviour
{
    [SerializeField] private bool UI;
    [SerializeField] private GameObject UITextObject;
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField] private new string name;
    [SerializeField] private int level;
    [SerializeField] private int health;
    [SerializeField] private int stamina;

    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Stamina { get; set; }

    private void Start()
    {
        textMeshProUGUI = UITextObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = $"{name}({level})\nHP:{health}\nST:{stamina}";

        Instantiate(UITextObject, transform.position, Quaternion.identity, transform);
    }

    private void Update()
    {
    }
}