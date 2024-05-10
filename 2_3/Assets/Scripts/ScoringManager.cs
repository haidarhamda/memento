using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringManager : MonoBehaviour
{
    [SerializeField] public int totalScore;
    [SerializeField] public Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: "+totalScore.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Dropable"))
        {
            DropableObject dropableObject = other.gameObject.GetComponent<DropableObject>();
            totalScore += dropableObject.score;
            Destroy(other.gameObject);
        }
    }
}
