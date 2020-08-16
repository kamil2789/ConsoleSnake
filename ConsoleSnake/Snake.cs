using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    public class Snake
    {
        private Coordinates head;
        private LinkedList<Coordinates> tails;

        public Snake(Coordinates startHead)
        {
            head = startHead;
            tails = new LinkedList<Coordinates>();
            tails.AddFirst(new Coordinates(head.cordX + 1, head.cordY));
        }

        public Snake(int headStartX, int headStartY)
        {
            head.cordX = headStartX;
            head.cordY = headStartY;
            tails = new LinkedList<Coordinates>();
            tails.AddFirst(new Coordinates(head.cordX + 1, head.cordY));
        }

        public Coordinates Head
        {
            get => head;
            set => head = value;
        }

        public LinkedList<Coordinates> Tails
        {
            get => tails;
        }

        public bool MoveSnake(Direction direction)
        {
            tails.RemoveLast();

            if (!IsCollisionWithTail(direction))
            {
                tails.AddFirst(new Coordinates(head.cordX, head.cordY));
                head = CalculateNewHeadPosition(direction);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExpandSnake(Direction direction)
        {
            if (!IsCollisionWithTail(direction))
            {
                tails.AddFirst(new Coordinates(head.cordX, head.cordY));
                head = CalculateNewHeadPosition(direction);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Coordinates CalculateNewHeadPosition(Direction direction)
        {
            Coordinates result = new Coordinates(head.cordX, head.cordY);
            switch (direction)
            {
                case Direction.Up:
                    result.cordY -= 1;
                    break;
                case Direction.Down:
                    result.cordY += 1;
                    break;
                case Direction.Left:
                    result.cordX -= 1;
                    break;
                case Direction.Right:
                    result.cordX += 1;
                    break;
            }

            return result;
        }

        private bool IsCollisionWithTail(Direction direction)
        {
            Coordinates futureHeadPosition = CalculateNewHeadPosition(direction);

            if (tails.Find(futureHeadPosition) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
