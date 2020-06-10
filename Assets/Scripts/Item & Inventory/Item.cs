using UnityEngine;

// This script is a component of a gameObject, which has a scriptable object item as it's property. 
// This is how scriptable object items can be put into the game.

public class Item : MonoBehaviour
{
    [SerializeField] private BaseItemScriptableObject itemScriptableObject;

    public BaseItemScriptableObject ItemScriptableObject
    {
        get => itemScriptableObject;
        set => itemScriptableObject = value;
    }
}
