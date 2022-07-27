using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());

        score = 0;
        UpdateScore(0);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }  
    }
}
