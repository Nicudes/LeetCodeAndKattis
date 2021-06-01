using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Tests
{
    class TryCreateDFS2dArrayFromMind
    {
        public static void CreateDFS()
        {
            int height = 0;
            int width = 0;

            //get the input of height and width
            int[] inputs = new int[width];
            inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            height = inputs[0];
            width = inputs[1];
            int[] row = new int[width];
            int[,] multiArr = new int[height, width];
            int[][] arrayOfRows = new int[height][];

            for (int i = 0; i < height; i++)
            {
                row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arrayOfRows[i] = row;
            }

            multiArr = To2D(arrayOfRows);


            static T[,] To2D<T>(T[][] source)
            {
                int fDim = source.Length;
                int sDim = source.GroupBy(row => row.Length).Single().Key;

                var result = new T[fDim, sDim];
                for (int i = 0; i < fDim; ++i)
                    for (int j = 0; j < sDim; ++j)
                        result[i, j] = source[i][j];

                return result;
            }

            //now that everything is set up and we have a 2DArray ready 
            //We need a Program State Manager

            //1. find the lowest Y[0] in the array to start off
            //2. Compare the options next to it and see which value is the lowest
            //3. Go to the lowest number and save the last position 
            //4. keep using the algorithm function until your X is at the highest value. 
            //4.5 Save the value and redo the algorithm a few times(as many times as Y allows) until you find the correct path
            //5. Print out the highest value you encountered while finding the lowest value paths.
            int lowestStartPosY = 0;
            int currentPosY = 0;
            int currentPosX = 0;
            int highestValueSoFar = 0;
            int prevPosY = 0;
            int prevPosX = 0;
            int direction = 0;

            if (height == 1 && width == 1)
            {
                Console.WriteLine(multiArr[0, 0]);
            }
            //GameCode
            setStartPosY();
            while (currentPosX != width - 1)
            {
                checkPath(currentPosY, currentPosX);
            }
            if (height != 1 && width != 1)
            {
                Console.WriteLine(highestValueSoFar);

            }

            void checkPath(int y, int x)
            {

                if (height == 1 && width != 1)
                {

                }



                //check available paths
                //Need to check previous used paths in a list 

                //You can only move  down and right 
                if (x == 0 && y == 0 && y != (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y + 1, x     },
                                                        { y    , x + 1 } };

                    bool hasMoved = false;
                    while (!hasMoved)
                    {

                        int[] tempArrForValues = new int[2];
                        for (int i = 0; i < 2; i++)
                        {
                            tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                        }
                        direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());

                        //Move Right
                        if (prevPosX != possiblePaths[1, 1] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;


                        };

                        //Move Down
                        if (prevPosY != possiblePaths[0, 0] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);
                        }
                    }
                }

                //You can move up, right and down but not left
                if (x == 0 && y != 0 && y != (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y - 1, x },
                                                        { y, x + 1 },
                                                        { y + 1, x } };

                    bool hasMoved = false;
                    while (!hasMoved)
                    {

                        int[] tempArrForValues = new int[3];
                        for (int i = 0; i < 3; i++)
                        {
                            tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                        }
                        direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());

                        //Move Right
                        if (prevPosX != possiblePaths[1, 1] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        };

                        //Move Up
                        if (prevPosY != possiblePaths[0, 0] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }


                        //Move Down
                        if (prevPosY != possiblePaths[2, 0] && direction == 2)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[2, 0];
                            currentPosX = possiblePaths[2, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);

                        }

                    }
                }

                //You can only move down, right and left
                if (y == 0 && x != 0 && y != (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y + 1, x },
                                                        { y, x + 1 },
                                                        { y, x - 1 } };
                    bool hasMoved = false;

                    int[] tempArrForValues = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                    }
                    direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());

                    while (!hasMoved)
                    {
                        //move Right
                        if (prevPosX != possiblePaths[1, 1] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;
                        };

                        //Move down
                        if (prevPosY != possiblePaths[0, 0] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }


                        //move left
                        if (prevPosX != possiblePaths[2, 1] && direction == 2)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[2, 0];
                            currentPosX = possiblePaths[2, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }
                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);
                        }
                    }

                }

                if (y != 0 && x != 0 && y != (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y + 1, x },
                                                        { y, x + 1 },
                                                        { y, x - 1 },
                                                        { y - 1, x } };

                    bool hasMoved = false;


                    int[] tempArrForValues = new int[4];
                    for (int i = 0; i < 4; i++)
                    {
                        tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                    }
                    direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());
                    while (!hasMoved)
                    {
                        //move Right
                        if (prevPosX != possiblePaths[1, 1] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        };

                        //Move down
                        if (prevPosY != possiblePaths[0, 0] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }


                        //move left
                        if (prevPosX != possiblePaths[2, 1] && direction == 2)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[2, 0];
                            currentPosX = possiblePaths[2, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        //move Up
                        if (prevPosY != possiblePaths[3, 0] && direction == 3)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[3, 0];
                            currentPosX = possiblePaths[3, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);
                        }

                    }

                }
                if (x == 0 && y == (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y, x + 1 },
                                                        { y - 1, x } };

                    bool hasMoved = false;
                    while (!hasMoved)
                    {

                        int[] tempArrForValues = new int[2];
                        for (int i = 0; i < 2; i++)
                        {
                            tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                        }
                        direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());

                        //Move Right
                        if (prevPosX != possiblePaths[0, 1] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        };

                        //Move Up
                        if (prevPosY != possiblePaths[1, 0] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);

                        }

                    }
                }

                if (x != 0 && y == (height - 1))
                {
                    int[,] possiblePaths = new int[,] { { y - 1, x },
                                                        { y, x + 1 },
                                                        { y, x - 1 } };

                    bool hasMoved = false;


                    int[] tempArrForValues = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        tempArrForValues[i] = multiArr[possiblePaths[i, 0], possiblePaths[i, 1]];
                    }
                    direction = Array.IndexOf(tempArrForValues, tempArrForValues.Min());
                    while (!hasMoved)
                    {
                        //Move Right
                        if (prevPosX != possiblePaths[1, 1] && direction == 1)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[1, 0];
                            currentPosX = possiblePaths[1, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        };

                        //Move Right
                        if (prevPosX != possiblePaths[2, 1] && direction == 2)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[2, 0];
                            currentPosX = possiblePaths[2, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        };

                        //Move Up
                        if (prevPosY != possiblePaths[0, 0] && direction == 0)
                        {
                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            prevPosY = currentPosY;
                            prevPosX = currentPosX;

                            currentPosY = possiblePaths[0, 0];
                            currentPosX = possiblePaths[0, 1];

                            if (multiArr[currentPosY, currentPosX] > highestValueSoFar)
                            {
                                highestValueSoFar = multiArr[currentPosY, currentPosX];
                            }
                            hasMoved = true;

                        }

                        if (!hasMoved)
                        {
                            int[] smallArr = new int[tempArrForValues.Length];

                            for (int i = 0; i < tempArrForValues.Length; i++)
                            {
                                smallArr[i] = tempArrForValues[i];
                            }
                            Array.Sort(smallArr);
                            int secondLowestNumber = smallArr[1];
                            direction = Array.FindIndex(tempArrForValues, number => number == secondLowestNumber);

                        }

                    }
                }
            }

            void getLowestStartNumber()
            {
                int[] tempArrForY = new int[height];
                for (int i = 0; i < height; i++)
                {
                    tempArrForY[i] = multiArr[i, 0];
                }
                lowestStartPosY = Array.IndexOf(tempArrForY, tempArrForY.Min());
            }


            void setStartPosY()
            {
                getLowestStartNumber();
                currentPosY = lowestStartPosY;
                prevPosY = lowestStartPosY;
            }


        }
    }

}

