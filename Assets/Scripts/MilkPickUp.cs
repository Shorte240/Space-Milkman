using UnityEngine;
using System.Collections;

public class MilkPickUp : MonoBehaviour
{
    public int pointsToAdd;

    public AudioSource milkSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);

        milkSoundEffect.Play();

        Destroy(gameObject);
    }
}
