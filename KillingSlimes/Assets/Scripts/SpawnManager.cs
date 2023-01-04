using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour //wall에 체력 만들어서 체력 0되면 게임 끝나게 포탐 설치 아이디어
{
    public GameObject player;
    public GameObject wall;
    public GameObject slime;

    Vector2 player_position = new Vector2(-8, 0);
    Vector2 wall_position = new Vector2(-7.25f, 0);
    float slime_x_position = 9.25f;
    float max_slime_y_position = 4.5f;
    float min_slime_y_position = -4.5f;

    bool is_game_end = false;

    void Start()
    {
        StartSpawnManager();
    }

    public void StartSpawnManager()
    {
        Instantiate(player, player_position, Quaternion.identity);
        Instantiate(wall, wall_position, Quaternion.identity);
        StartCoroutine(SpawnSlime());
    }

    IEnumerator SpawnSlime()
    {
        float spawn_delay;
        float min_spawn_delay = 2.5f;
        float max_spawn_delay = 5f;
        int spawn_amount;
        Vector2 spawn_position;
        Color color;
        GameObject temp;

        while (is_game_end == false)
        {
            spawn_delay = Random.Range(min_spawn_delay, max_spawn_delay);
            spawn_amount = Random.Range(0, 5);

            for (int i = 0; i < spawn_amount; i++)
            {
                spawn_position = new Vector2(slime_x_position, Random.Range(min_slime_y_position, max_slime_y_position));
                color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

                temp = Instantiate(slime, spawn_position, Quaternion.identity);
                temp.GetComponent<SpriteRenderer>().material.color = color;
            }

            yield return new WaitForSeconds(spawn_delay);
        }
    }
}
