using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private lifeScript playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<lifeScript>();
        totalHealthBar.fillAmount = playerHealth.returnLives() / 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.returnLives() / 10.0f;
    }
}
