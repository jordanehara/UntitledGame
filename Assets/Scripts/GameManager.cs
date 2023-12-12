using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;

    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;
    public int lives = 3;
    public int score = 0;

    public void EnemyDestroyed(Enemy enemy)
    {
        this.explosion.transform.position = enemy.transform.position;
        this.explosion.Play();

        // TODO: score increase
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;
        if (this.lives <= 0)
            GameOver();
        else
            Invoke(nameof(Respawn), respawnTime);
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        // TODO
    }
}