using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringManager : MonoBehaviour
{
    [SerializeField] public int totalScore;

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
