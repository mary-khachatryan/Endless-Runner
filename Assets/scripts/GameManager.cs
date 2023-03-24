using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject Player;
    public PlayerController playerController;
    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(1f, 2f);
            yield return  new WaitForSeconds(waitTime);
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    
    
    }

    public void GameStart()
    {
        Player.SetActive(true);
        playButton.SetActive(false);
        playerController.animator.SetBool("run", true);
        StartCoroutine(SpawnObstacles());
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
