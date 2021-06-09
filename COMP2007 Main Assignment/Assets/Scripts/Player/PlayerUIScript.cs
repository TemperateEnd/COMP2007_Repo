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

        if(playerHealthManager.hpState == HealthManager.healthState.LosingHP)
        {
            player.GetComponent<AudioManager>().audioSource.clip = player.GetComponent<AudioManager>().soundFX[0];
            player.GetComponent<AudioManager>().audioSource.PlayOneShot(player.GetComponent<AudioManager>().audioSource.clip, 75.0f);
        }

        else if(playerHealthManager.hpState == HealthManager.healthState.GainingHP)
        {
            player.GetComponent<AudioManager>().audioSource.clip = player.GetComponent<AudioManager>().soundFX[1];
            player.GetComponent<AudioManager>().audioSource.PlayOneShot(player.GetComponent<AudioManager>().audioSource.clip, 75.0f);
        }
    }
}
