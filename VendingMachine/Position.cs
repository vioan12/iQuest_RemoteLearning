﻿
namespace VendingMachine
{
    public class Position
    {
        public int row { get; private set;}
        public int column { get; private set;}
        public Position(int row, int column)
        {
            this.row=row;
            this.column=column;
        }
        public int CompareWith(Position secondposition)
        {
            if(row != secondposition.row)
            {
                return 1;
            }
            if (column != secondposition.column)
            {
                return 1;
            }
            return 0;
        }
    }
}
