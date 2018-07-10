using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tetris.Sprites;

namespace Tetris
{
    internal class Grid
    {
        private const int Columns = 10;
        private const int Rows = 21;
        private readonly int[,] _array;

        private readonly int _offsetX;
        private readonly int _offsetY;

        public Grid(int offsetX, int offsetY)
        {
            _array = new int[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _array[i, j] = 0;
                }
            }

            _offsetX = offsetX;
            _offsetY = offsetY;
        }

        public void Draw(SpriteBatch spriteBatch, Color tint, Texture2D blockTexture, Texture2D bgTexture, Texture2D borderTexture)
        {
            Sprite leftCornerBlock = new StaticAtlasSprite(borderTexture, new Point(32, 32), Point.Zero);
            Point borderPoint = new Point(_offsetX - 32, _offsetY + (Rows - 1) * 32);
            leftCornerBlock.Draw(spriteBatch, tint, borderPoint);

            Sprite rightCornerBlock = new StaticAtlasSprite(borderTexture, new Point(32, 32), Point.Zero);
            borderPoint = new Point(_offsetX + (Columns) * 32, _offsetY + (Rows - 1) * 32);
            rightCornerBlock.Draw(spriteBatch, tint, borderPoint);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Sprite bgBlock = new StaticAtlasSprite(bgTexture, new Point(32, 32), Point.Zero);
                    Point bgPosition = new Point(_offsetX + j * 32, _offsetY + (i - 1) * 32);
                    bgBlock.Draw(spriteBatch, tint, bgPosition);

                    Sprite borderBlock = new StaticAtlasSprite(borderTexture, new Point(32, 32), Point.Zero);
                    if (j == 0)
                    {
                        borderPoint = new Point(_offsetX - 32, _offsetY + (i - 1) * 32);
                        borderBlock.Draw(spriteBatch, tint, borderPoint);
                    } else if (j == Columns - 1)
                    {
                        borderPoint = new Point(_offsetX + (j + 1) * 32, _offsetY + (i - 1) * 32);
                        borderBlock.Draw(spriteBatch, tint, borderPoint);
                    }

                    if (i == Rows - 1)
                    {
                        borderPoint = new Point(_offsetX + j * 32, _offsetY + (i) * 32);
                        borderBlock.Draw(spriteBatch, tint, borderPoint);
                    }

                    if (_array[i, j] == 1)
                    {
                        Sprite block = new StaticAtlasSprite(blockTexture, new Point(32, 32), Point.Zero);
                        Point position = new Point(_offsetX + j * 32, _offsetY + (i - 1) * 32);
                        block.Draw(spriteBatch, tint, position);
                    }
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < Rows; i++)
            {
                bool lineComplete = true;

                for (int j = 0; j < Columns; j++)
                {
                    if (_array[i,j] == 0)
                    {
                        lineComplete = false;
                        //break;
                    }
                }

                if (lineComplete)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        _array[i, j] = 0;
                    }

                    //Shift rows above down
                    for (int k = i - 1; k >= 0; k--)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            _array[k + 1, j] = _array[k, j];
                        }
                    }


                }
            }
        }

        public int GetColumns()
        {
            return Columns;
        }

        public int GetRows()
        {
            return Rows;
        }

        public int[,] GetArray()
        {
            return _array;
        }
    }
}
