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
        int levelSelect;

        int numWeights;
        int generationSize;

        int inputWidth;
        int inputHeight;
        int hiddenNodes;

        int current = 0;

        int generationsBetweenWrites;
        int generationsSinceWrite = 0;

        bool generationOver = false;

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
            InitializeComponent();
        }

        public void Load(string file)
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

                        int[] w = new int[numWeights];

                        for (int i = 0; i < numWeights; i++)
                        {
                            w[i] = Convert.ToInt32(chunks[i]);
                        }

                        computers.Add(new Computer(w));

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
            int numGenerations = (int)inGenerations.Value;
            if (inRunForever.Checked) numGenerations = -1;

            //I'll deal with this later, hard coded for now
            int levelSelect = 1;

            generationsBetweenWrites = (int)inBetweenWrites.Value;

            Load(file);

            //we should have everything we need here, hand control over to the game
            game.GameState = GameState.Play;
        }

        #endregion

        public void Update(GameTime gameTime)
        {
            if (generationOver)
            {
                generationsSinceWrite++;
                if (generationsSinceWrite >= generationsBetweenWrites)
                {
                    generationsSinceWrite = 0;
                    //write the files
                }

                //sort the generation by score
                //drop the lower half
                //breed new generation
                generationOver = false;
                //start over
            }

            GameState state = game.GameState;
            switch (state)
            {
                case GameState.Start:
                    break;

                case GameState.Play:
                    //get inputs,
                    //pass inputs to the neural network,
                    //pass back the actions to take
                    break;

                case GameState.Lose:
                    //score and record stats
                    //reset game
                    //get next computer or mark generation over
                    //restart
                    break;

                default:
                    break;
            }
        }

    }
}
