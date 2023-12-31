using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndicator : MonoBehaviour
{
    public int[,] line_data = new int[5, 5]
    {
        {  0, 1,  2,   3 , 4 },

        {  5, 6,  7,   8,  9 },

        { 10, 11, 12,  13, 14},

        { 15, 16, 17,  18, 19},

        { 20, 21, 22,  23, 24,},
};

    public int[,] square_data = new int[5, 5]
    {
        { 0, 5, 10, 15, 20 },

        { 1, 6, 11, 16, 21 },

        { 2, 7, 12, 17, 22 },

        { 3, 8, 13, 18, 23 },

        { 4, 9, 14, 19, 24 }
    };

    [HideInInspector]
    public int[] columnIndexes = new int[5]
    {
        0, 1, 2, 3, 4
    };

    private (int, int) GetSquarePosition(int square_index)
    {
        int pos_row = -1;
        int pos_col = -1;

        for (int row = 0; row < 5; row++)
        {
            for ( int col = 0; col < 5; col ++)
            {
                if (line_data[row,col] == square_index)
                {
                    pos_row = row;
                    pos_col = col;
                }
            }
        }

        return (pos_row, pos_col);
    }

    public int[] GetVerticalLine ( int square_index)
    {
        int[] line = new int[5];

        var square_position_col = GetSquarePosition(square_index).Item2;

        for ( int index = 0; index < 5; index ++)
        {
            line[index] = line_data[index, square_position_col];
        }
        return line;
    }

    public int GetGridSquareIndex (int square)
    {
        for ( int row = 0; row < 5; row ++)
        {
            for ( int col = 0; col < 5; col ++)
            {
                if (square_data[row, col] == square)
                {
                    return row;
                }
            }
        }
        return -1;
    }

}