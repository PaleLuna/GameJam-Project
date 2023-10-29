using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItemDescription", menuName = "Configs/Items/Stats")]
public class ItemDescription : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private Sprite _icon;

    public string itemName => _name;
    public Sprite icon => _icon;
}