using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCham : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private GameManager gm;
    private AudioManager am;
    private void Awake()
    {
        gm = FindAnyObjectByType<GameManager>();
        am = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            am.PlayCoin();
            gm.AddDiem(1);
        }
        else if(collision.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            gm.GameOver();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gm.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            gm.GameWin();  
        }
    }
}
