using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hazardPrefab;
    public float maxHazardToSpawn = 3;
    public TMPro.TextMeshPro scoreText;

    private int score;
    private float timer;
    private static bool gameOver;

    void Start()
    {
        StartCoroutine(SpawnHazards());
    }

    private void Update() {

        if(gameOver)
            return ;

        
        timer += Time.deltaTime;

        if(timer >= 1f) {
            score++;
            scoreText.text  = score.ToString();

            timer = 0;
        }
    }

    private IEnumerator SpawnHazards() {
        var hazardToSpawn = Random.Range(1, maxHazardToSpawn) ;

        for(int i = 0; i < hazardToSpawn; i++) {
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);
            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);

            hazard.GetComponent<Rigidbody>().drag = drag;
        }

        var timeToWait = Random.Range(0.5f, 1.5f);

        yield return new WaitForSeconds(timeToWait);
        yield return SpawnHazards();
    }

    public static void GameOver() {
        gameOver = true;
    }
}
