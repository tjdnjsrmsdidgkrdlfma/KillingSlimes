using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] floor_tiles;
    public GameObject[] wall_tiles;
    public GameObject[] grass_tiles;

    Vector2 up_left_floor_tiles = new Vector2(-6.75f, 4.75f);
    Vector2 down_right_floor_tiles = new Vector2(8.75f, -4.75f);
    Vector2 up_left_wall_tiles = new Vector2(-7.25f, 4.75f);
    Vector2 down_right_wall_tiles = new Vector2(-7.25f, -4.75f);
    Vector2 up_left_grass_tiles = new Vector2(-8.75f, 4.75f);
    Vector2 down_right_grass_tiles = new Vector2(-7.75f, -4.75f);

    void Start()
    {
        StartMapManager();
    }

    public void StartMapManager()
    {
        CreateTiles(floor_tiles, up_left_floor_tiles, down_right_floor_tiles, "FloorTiles", true);
        CreateTiles(wall_tiles, up_left_wall_tiles, down_right_wall_tiles, "WallTiles", false);
        CreateTiles(grass_tiles, up_left_grass_tiles, down_right_grass_tiles, "FloorTiles", false);
    }

    void CreateTiles(GameObject[] tile_list, Vector2 up_left, Vector2 down_right, string parent_object_name, bool rotate)
    {
        GameObject tile_map = new GameObject(parent_object_name);
        GameObject random_tile;
        Vector2 tile_position;
        Vector3 tile_rotation;
        GameObject temp;

        for (float x = up_left.x; x <= down_right.x; x += 0.5f)
        {
            for (float y = down_right.y; y <= up_left.y; y += 0.5f)
            {
                random_tile = tile_list[Random.Range(0, tile_list.Length)];
                tile_position = new Vector2(x, y);
                if (rotate == true)
                    tile_rotation = new Vector3(0, 0, Random.Range(0, 4) * 90);
                else
                    tile_rotation = Vector3.zero;

                Instantiate(tile_list[0], tile_position, Quaternion.identity);

                temp = Instantiate(random_tile, tile_position, Quaternion.Euler(tile_rotation));

                temp.transform.SetParent(tile_map.transform);
            }
        }
    }
}
