using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //18 x 10
    public GameObject[] tiles;

    int row = 18;
    int column = 10;

    void SetUp()
    {
        GameObject tile_map = new GameObject("TileMap");

        for (int x = row / 2 * -1; x <= row / 2; x++)
        {
            for (int y = column / 2 * -1; y <= column / 2; y++)
            {
                GameObject random_tile = tiles[Random.Range(0, tiles.Length)];
                Vector2 tile_position = new Vector2(x, y);

                Instantiate(tiles[0], tile_position, Quaternion.identity);

                GameObject temp = Instantiate(random_tile, tile_position, Quaternion.identity); //스프라이트를 프래팹으로 만들어서 게임오브젝트로 변경한다
            }
        }
    }
}
