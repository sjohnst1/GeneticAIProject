using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.IO;

namespace Platformer.Controller
{
    public partial class Controller : Form
    {
        #region Fields

        PlatformerGame game;
        List<Computer> computers;

        int numGenerations;
        int generationsRun = 0;

        int numWeights;
        int generationSize;

        int inputWidth;
        int inputHeight;
        int hiddenNodes;

        int current = 0;

        int generationsBetweenWrites;
        int generationsSinceWrite = 0;

        float timeLimit = 10;
        float timeRemaining;


        #endregion

        #region Properties

        public bool StopGame
        {
            get;
            protected set;
        }

        #endregion

        #region Initialization
        
        public Controller()
        {
            InitializeComponent();
        }

        public Controller(PlatformerGame game)
        {
            this.game = game;
            StopGame = false;
            timeRemaining = timeLimit;
            InitializeComponent();
        }

        public void LoadFile(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line = sr.ReadLine();
                    
                    //first line, input width
                    inputWidth = Convert.ToInt32(line);

                    line = sr.ReadLine();
                    
                    //second line, input height
                    inputHeight = Convert.ToInt32(line);

                    line = sr.ReadLine();

                    //third line, number of hidden nodes
                    hiddenNodes = Convert.ToInt32(line);

                    numWeights = (inputWidth * inputHeight * hiddenNodes) + (3 * hiddenNodes);

                    line = sr.ReadLine();

                    //fourth line, number of rows in the file (generation size)
                    generationSize = Convert.ToInt32(line);

                    line = sr.ReadLine();

                    computers = new List<Computer>(generationSize);

                    //now get the weight strings
                    //x counts the lines so we only get the number we expect
                    int x = 0;

                    while (line != null && x < generationSize)
                    {
                        string[] chunks = line.Split(',');

                        float[] w = new float[numWeights];

                        for (int i = 0; i < numWeights; i++)
                        {
                            //w[i] = Convert.ToInt32(chunks[i]);
                            w[i] = (float)Convert.ToDouble(chunks[i]);
                        }

                        computers.Add(new Computer(w, inputWidth, inputHeight, hiddenNodes));

                        line = sr.ReadLine();
                        x++;
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        #region Form Event Handlers

        private void btStart_Click(object sender, EventArgs e)
        {
            string file = inWeightFile.Text;
            numGenerations = (int)inGenerations.Value;
            if (inRunForever.Checked) numGenerations = -1;

            generationsBetweenWrites = (int)inBetweenWrites.Value;

            LoadFile(file);

            //we should have everything we need here, hand control over to the game
            game.GameState = GameState.Play;
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            outStatusBox.Text += "Stop command accepted. Simulation will exit when generation is over and files have been written.\n";
            StopGame = true;
        }


        private void btBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog.FileName;

                    inWeightFile.Text = File.ReadAllText(file);

                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Neural Network Handlers

        protected void HandleGenerationOver()
        {
            outStatusBox.Text = "Generation over.";
            computers.Sort();
            SaveScores();

            generationsSinceWrite++;
            generationsRun++;

            if (generationsRun >= numGenerations || StopGame)
            {
                //we're done here
                WriteGenerationsFile();
                game.Exit();
            }
            else
            {
                //go to next generation and restart

                if (generationsSinceWrite >= generationsBetweenWrites)
                {
                    generationsSinceWrite = 0;
                    WriteGenerationsFile();
                }

                BreedGeneration();
                game.ResetGame();
                timeRemaining = timeLimit;
            }

        }

        protected void BreedGeneration()
        {
            outStatusBox.Text = "Breeding new generation...";
            List<Computer> temp = new List<Computer>(generationSize);

            int total = 0;

            foreach (Computer c in computers)
            {
                c.CuSum = c.TileDistance + total;
                total += c.TileDistance;
            }

            int half = generationSize / 2;
            for(int i = 0; i < half; i++)
            {
                temp.Add(GetRandom(computers, total));
            }
            for (int i = half; i < generationSize; i++)
            {
                //breed to fill in generation
                Computer c1 = GetRandom(computers, total);
                Computer c2 = GetRandom(computers, total);
                temp.Add(c1.BreedWith(c2));
            }
            current = 0;
            outStatusBox.Text = "New generation has been created.";
        }

        protected Computer GetRandom(List<Computer> c, int total)
        {
            Random r = new Random();
            int find = r.Next(0, total + 1);

            int start = 0;
            int end = c.Count;

            while (true)
            {
                //I have too many base cases I'm sure they overlap
                //I don't care, watch me cover all my bases
                //BINARY SEARCH WOOOO
                if (start == end) return c[start];
                if (c[start].CuSum == find) return c[start];
                if (c[end - 1].CuSum == find) return c[end - 1];
                
                //if there's only 2, pick the right
                if (end - start == 1) return c[end - 1];

                //otherwise let's SNIP THE LIST
                int i = (start + end) / 2;
                if (find < c[i].CuSum) end = i;
                else start = i;
            }

        }

        protected void SaveScores()
        {
            outStatusBox.Text = "Writing scores to file...";
            //save high score, low score, median score, and average score
            //some identifier? Timestamp? Generation #?
            string output = "";
            output += inputWidth + "," + inputHeight + "," + hiddenNodes + "," + generationSize + ",";
            output += generationsRun + ",";
            output += computers[0].TileDistance + ",";
            output += computers[generationSize - 1].TileDistance + ",";
            output += computers[generationSize / 2].TileDistance + ",";

            float avgScore = 0;
            foreach (Computer c in computers) avgScore += c.TileDistance;
            avgScore = avgScore / (float)generationSize;
            output += avgScore;

            //append it to scores file
            using (StreamWriter writer = new StreamWriter("scores.txt", true))
            {
                writer.WriteLine(output);
            }
            outStatusBox.Text = "File write complete.";
        }

        protected void WriteGenerationsFile()
        {
            //spit computer list out to file
            outStatusBox.Text = "Writing generation file...";
            using (StreamWriter writer = new StreamWriter("generation.txt"))
            {
                writer.WriteLine(inputWidth);
                writer.WriteLine(inputHeight);
                writer.WriteLine(hiddenNodes);
                writer.WriteLine(generationSize);

                foreach (Computer c in computers)
                {
                    writer.WriteLine(c.ToString());
                }
            }
            outStatusBox.Text = "File write complete.";
        }

        #endregion

        public void Update(GameTime gameTime)
        {
            GameState state = game.GameState;
            switch (state)
            {
                case GameState.Start:
                    break;

                case GameState.Play:
                    if (timeRemaining <= 0) game.GameState = GameState.Lose;
                    else
                    {

                        //get inputs,
                        int[] input = game.GetNNInput(inputWidth, inputHeight);
                        //pass inputs to the neural network,
                        int[] output = computers[current].GetOutput(input);
                        //pass back the actions to take
                        game.Player.Actions = output;

                        //test mode: print the inputs and distance out to the textbox
                        outStatusBox.Text = "";
                        //outStatusBox.Text += "Distance: " + game.GetDistance() + "\r\n";
                        //for (int y = 0; y < inputHeight; y++)
                        //{
                        //    for (int x = 0; x < inputHeight; x++)
                        //    {
                        //        outStatusBox.Text += input[inputWidth * y + x] + " ";
                        //    }
                        //    outStatusBox.Text += "\r\n";
                        //}
                        timeRemaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                        //output from the NN! ZOMG
                        //outStatusBox.Text += "\r\n";
                        for (int i = 0; i < output.Length; i++)
                        {
                            outStatusBox.Text += output[i] + " ";
                        }
                    }

                    break;

                case GameState.Win:
                case GameState.Lose:

                    //score and record stats
                    computers[current].TileDistance = game.GetDistance();
                    current++;

                    if (current >= computers.Count)
                    {
                        //handle generation over
                        HandleGenerationOver();
                    }
                    else
                    {
                        //restart
                        game.ResetGame();
                        timeRemaining = timeLimit;
                    }


                    break;

                default:
                    break;
            }
        }



    }
}
