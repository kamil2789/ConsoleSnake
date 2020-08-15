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
            if (!IsCollisionWithTail(direction))
            {
                tails.RemoveLast();
                tails.AddFirst(new Coordinates(head.cordX, head.cordY));
                head = MoveSnakeHead(direction);

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
                head = MoveSnakeHead(direction);

                return true;
            }
            else
            {
                return false;
            }
        }

        private Coordinates MoveSnakeHead(Direction direction)
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
            Coordinates futureHeadPosition = MoveSnakeHead(direction);
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
