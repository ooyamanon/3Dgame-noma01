using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeStick : MonoBehaviour
{
    public int max_z;
    public int max_x;
    int z;
    int x;
    int r;
    Object wall;
    GameObject wallgo;

    // Start is called before the first frame update
    void Start()
    {
        int[,] field = new int[max_z, max_x];
        wall = Resources.Load("Wall");
        
        // 通路（０）の生成
        for (z = 0; z < max_z; z = z + 1)
        {
            for (x = 0; x < max_x; x = x + 1)
            {
                field[z, x] = 0;
            }
        }

        // 上下の外壁（１）の生成
        for (x = 0; x < max_x; x = x + 1)
        {
            field[0, x] = 1;
            field[max_z - 1, x] = 1;
        }

        // 左右の外壁（１）の生成
        for (z = 0; z < max_z; z = z + 1)
        {
            field[z, 0] = 1;
            field[z, max_x-1] = 1;
        }

        // 棒倒し法を使った壁（１）の生成(1行目のみ)
        z = 2; // 1行目
        for (x = 2; x < max_x - 1; x = x + 2)
        {
            r = Random.Range(1, 13);
            field[z, x] = 1;
            if (r <= 3) // rが3以下のとき
            {
                if (field[z - 1, x] == 0)
                {
                    field[z - 1, x] = 1;
                }
                else if (field[z - 1, x] == 1)
                {
                    x = x - 2;
                }
            }
            if (r >= 4 && r <= 6) //rが4から6のとき 
            {
                if (field[z + 1, x] == 0)
                {
                    field[z + 1, x] = 1;
                }
                else if (field[z + 1, x] == 1)
                {
                    x = x - 2;
                }
            }
            if (r >= 7 && r <= 9) //rが7から9のとき
            {
                if (field[z, x - 1] == 0)
                {
                    field[z, x - 1] = 1;
                }
                else if (field[z, x - 1] == 1)
                {
                    x = x - 2;
                }
            }
            if (r >= 10) // rが10以上のとき
            {
                if (field[z, x + 1] == 0)
                {
                    field[z, x + 1] = 1;
                }
                else if (field[z, x + 1] == 1)
                {
                    x = x - 2;
                }
            }
        }

        // 棒倒し法を使った壁（１）の生成(2行目以降)
        for (z = 4; z < max_z - 1; z = z + 2)
        {
            for (x = 2; x < max_x - 1; x = x + 2)
            {
                r = Random.Range(1, 13);
                field[z, x] = 1;
                if (r <= 4) // rが4以下のとき
                {
                    if (field[z + 1, x] == 0)
                    {
                        field[z + 1, x] = 1;
                    }
                    else if (field[z + 1, x] == 1)
                    {
                        x = x - 2;
                    }
                }
                if (r >= 5 && r <= 8) //rが5から8のとき
                {
                    if (field[z, x - 1] == 0)
                    {
                        field[z, x - 1] = 1;
                    }
                    else if (field[z, x - 1] == 1)
                    {
                        x = x - 2;
                    }
                }
                if (r >= 9) // rが9以上のとき
                {
                    if (field[z, x + 1] == 0)
                    {
                        field[z, x + 1] = 1;
                    }
                    else if (field[z, x + 1] == 1)
                    {
                        x = x - 2;
                    }
                }
            }
        }

        field[0, 1] = 0; // スタート地点の壁を撤去する
        field[max_z - 1, max_x - 2] = 0; // ゴール地点の壁を撤去する

        // 壁の配置
        for (z = 0; z < max_z; z = z + 1)
        {
            for (x = 0; x < max_x; x = x + 1)
            {
                if (field[z, x] == 0) // 通路なら
                {
                    // 何も配置しない
                }
                else if (field[z, x] == 1) // 壁なら
                {
                    wallgo = (GameObject)Instantiate(wall, new Vector3(5.0f * x, 2.5f, 5.0f * z), Quaternion.identity); // 壁を配置する
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
