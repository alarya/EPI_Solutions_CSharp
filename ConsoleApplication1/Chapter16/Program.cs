using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EPI16_Q1
{
    public class node
    {
        public int row;
        public int column;
    }
    class Program
    {
        int[,] visited;
        int[,] maze;
        int rowBounds ;
        int columnBounds ;
        int endRow;
        int endColumn;
        List<node> path;
        public void solveMaze(int[,] maze, int startRow, int startColumn, int endRow, int endColumn)
        {
            rowBounds = maze.GetUpperBound(0);
            columnBounds = maze.GetUpperBound(1);

            this.maze = maze;
            this.endRow = endRow;
            this.endColumn = endColumn;
            this.visited = new int[rowBounds+1, columnBounds+1];
            visited[startRow, startColumn] = 1;
            path = new List<node>();
            node _node = new node();
            _node.row = startRow; _node.column = startColumn;
            this.path.Add(_node);
            Search(_node);
        }

        public void Search(node _node)
        {
            if(_node.row == this.endRow && _node.column == this.endColumn)
            {
                foreach (node n in this.path)
                    Console.Out.Write("{0},{1} ", n.row, n.column);

                return;
            }

            //check if any neighbouring locations are not visited and reachable
            int topRow = _node.row - 1; int topColumn = _node.column;
            int leftRow = _node.row ; int leftColumn = _node.column - 1 ;
            int bottomRow = _node.row + 1; int bottomColumn = _node.column;
            int rightRow = _node.row ; int rightColumn = _node.column + 1;

            if(valid(topRow,topColumn))
            {
                node next = new node();
                next.row = topRow; next.column = topColumn;
                visited[topRow, topColumn] = 1;
                this.path.Add(next);
                Search(next);
                this.path.Remove(next);
            }
            if (valid(leftRow, leftColumn))
            {
                node next = new node();
                next.row = leftRow; next.column = leftColumn;
                visited[leftRow, leftColumn] = 1;
                this.path.Add(next);
                Search(next);
                this.path.Remove(next);
            }
            if (valid(bottomRow, bottomColumn))
            {
                node next = new node();
                next.row = bottomRow; next.column = bottomColumn;
                visited[bottomRow, bottomColumn] = 1;
                this.path.Add(next);
                Search(next);
                this.path.Remove(next);
            }
            if (valid(rightRow, rightColumn))
            {
                node next = new node();
                next.row = rightRow; next.column = rightColumn;
                visited[rightRow, rightColumn] = 1;
                this.path.Add(next);
                Search(next);
                this.path.Remove(next);
            }

            return;
        }
        public bool valid(int row, int column)
        {
            if ((row <= rowBounds && row >= 0) && (column <= columnBounds && column >= 0)) 
            {
                if (maze[row, column] != 1)
                {
                    if (visited[row, column] != 1)
                        return true;
                }
            }
            return false;
        }

#if(TEST_Q1)
        static void Main(string[] args)
        {
            int[,] maze = new int[,] {
                            { 1,0,0,0,0,0,1,1,0,0 },
                            { 0,0,1,0,0,0,0,0,0,0 },
                            { 1,0,1,0,0,1,1,0,1,1 },
                            { 0,0,0,1,1,1,0,0,1,0 },
                            { 0,1,1,0,0,0,0,0,0,0 },
                            { 0,1,1,0,0,1,0,1,1,0 },
                            { 0,0,0,0,1,0,0,0,0,0 },
                            { 1,0,1,0,1,0,1,0,0,0 },
                            { 1,0,1,1,0,0,0,1,1,1 },
                            { 0,0,0,0,0,0,0,1,1,0 }
                            };
            // 0's indicate white and 1's indicate black

            //int[,] maze = new int[,] {
            //                { 1,1,0,0,0,0,1,1,0,0 },
            //                { 0,0,1,0,0,0,0,0,0,0 },
            //                { 1,0,1,0,0,1,1,0,1,1 },
            //                { 0,0,0,1,1,1,0,0,1,0 },
            //                { 0,1,1,0,0,0,0,0,0,0 },
            //                { 0,1,1,0,0,1,0,1,1,0 },
            //                { 0,0,0,0,1,0,0,0,0,0 },
            //                { 1,0,1,0,1,0,1,0,0,0 },
            //                { 1,0,1,1,0,0,0,1,1,1 },
            //                { 0,0,0,0,0,0,0,1,1,0 }
            //                };

            //int[,] maze = new int[,] {
            //                { 1,1,0,0,0,0,1,1,0,0 },
            //                { 0,0,1,0,0,0,0,0,0,0 },
            //                { 1,0,1,0,0,1,1,0,1,1 },
            //                { 0,0,0,1,1,1,0,0,1,0 },
            //                { 0,1,1,0,0,0,0,0,0,0 },
            //                { 0,1,1,0,0,1,0,1,1,0 },
            //                { 0,0,0,0,1,0,0,0,0,0 },
            //                { 1,0,1,0,1,0,1,0,0,0 },
            //                { 1,1,1,1,0,0,0,1,1,1 },
            //                { 0,0,1,0,0,0,0,1,1,0 }
            //                };

            int startRow = 9;
            int startColumn = 0;
            int endRow = 0;
            int endColumn = 9;

            Program P = new Program();
            P.solveMaze(maze, startRow, startColumn, endRow, endColumn);

            Console.ReadKey();
        }
#endif
    }
}
