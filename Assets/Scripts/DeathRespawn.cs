using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRespawn : MonoBehaviour
{
    public BoxCollider2D deathCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == deathCollider)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
