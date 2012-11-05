using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.Controller
{
    public class Computer : IComparable<Computer>
    {
        float[] weights;

        int tileDistance = 0;
        int cuSum = 0;

        int inputWidth;
        int inputHeight;
        int hiddenNodes;

        public float[] Weights
        {
            get { return weights; }
        }

        public int TileDistance
        {
            get { return tileDistance; }
            set { tileDistance = value; }
        }

        public int CuSum
        {
            get { return cuSum; }
            set { cuSum = value; }
        }

        /// <summary>
        /// Initializes bot
        /// </summary>
        /// <param name="v">Array of weight values between -1 and 1</param>
        /// <param name="m">Input width</param>
        /// <param name="n">Input Height</param>
        /// <param name="k">Number of hidden nodes</param>
        public Computer(float[] v, int m, int n, int k)
        {
            weights = v;
            inputWidth = m;
            inputHeight = n;
            hiddenNodes = k;
        }

        public int[] GetOutput(int[] input)
        {
            float[] mid = new float[hiddenNodes];
            for (int m = 0; m < hiddenNodes; m++) mid[m] = 0;

            int hiddenStep = inputWidth * inputHeight;

            //hidden layer

            //THIS IS WRONG
            //for (int i = 0; i < hiddenNodes; i++ )
            //{
            //    for (int j = i * hiddenStep; j < (i + 1) * hiddenStep; j++)
            //    {
            //        mid[i] += weights[j] * input[j];
            //    }

            //    if (mid[i] <= 0) mid[i] = 0;
            //    else mid[i] = 1;
            //}

            for (int i = 0; i < hiddenNodes; i++)
            {
                for (int j = 0; j < hiddenStep; j++)
                {
                    mid[i] += input[j] * weights[(i * hiddenStep) + j];
                }
            }

            float[] almostOutput = new float[]{0,0,0};

            int[] output = new int[3];
            
            //output layer
            int outputStart = inputWidth * inputHeight * hiddenNodes;

            //ALSO WRONG WHAT ARE YOU DOING
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = i * outputStep; j < (i + 1) * outputStep; j++)
            //    {
            //        almostOutput[i] += weights[j + outputStart] * mid[j];
            //    }

            //    if (almostOutput[i] <= 0) output[i] = 0;
            //    else output[i] = 1;
            //}

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < hiddenNodes; j++)
                {
                    almostOutput[i] += mid[j] * weights[outputStart + (i * hiddenNodes) + j];
                }

                if (almostOutput[i] <= 0) output[i] = 0;
                else output[i] = 1;
            }





            return output;
        }

        public int CompareTo(Computer other)
        {
            //return TileDistance.CompareTo(other.TileDistance);
            return other.TileDistance.CompareTo(TileDistance);
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < weights.Length; i++)
            {
                output += weights[i];
                if (i != weights.Length - 1) output += ",";
            }
            return output;
        }

        public Computer BreedWith(Computer other)
        {
            Random r = new Random();
            int start = r.Next(weights.Length - 1);
            int end = r.Next(start, weights.Length);
            float[] w = new float[weights.Length];
            Array.Copy(weights, w, weights.Length);

            for (int i = start; i < end; i++)
            {
                w[i] = other.weights[i];
            }
            for (int i = 0; i < w.Length; i++)
            {
                if (r.NextDouble() < .05)
                {
                    w[i] = ((float)r.NextDouble() * 2) - 1;
                }
            }

            return new Computer(w, inputWidth, inputHeight, hiddenNodes);
        }

    }
}
