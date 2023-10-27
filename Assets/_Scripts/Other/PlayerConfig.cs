using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerStats", menuName = "Configs/Player/Stats")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField, Min(0)] private float _speed;

    [SerializeField, Min(0)] private int _maxHealth;

    public float Speed => _speed;
    public float MaxHealth => _maxHealth;
    
    
    public void Copy(PlayerConfig other)
    {
        this._speed = other.Speed;
        this._maxHealth = other._maxHealth;
    }
}