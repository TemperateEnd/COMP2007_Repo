using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int enemiesKilled;
    [SerializeField] private HealthManager playerHealthManager;
    public Slider healthSlider;
    public TextMeshProUGUI killCountText;
    
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        playerHealthManager = player.GetComponent<HealthManager>();
        healthSlider.maxValue = playerHealthManager.maxHP;

        healthSlider.value = playerHealthManager.currHP; //Sets current value of slider to value of currHP
        killCountText.SetText(enemiesKilled + " enemies killed so far"); //Shows player how many enemies they took out
    }


}
