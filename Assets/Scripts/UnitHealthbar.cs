using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class UnitHealthbar : MonoBehaviour
{

    public float health;
    public float maxHealth;

    public GameObject healthBarUi;
    public Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUi.SetActive(true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
