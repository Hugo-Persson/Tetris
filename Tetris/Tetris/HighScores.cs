using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [Serializable]
    class HighScores
    {
        int[] scores = new int[5];
        string[] scoreNames = new string[5];

        public int CheckForNewHighScore(int score)
        {
            int index = 0;
            foreach(int i in scores)
            {
                if (score > i)
                {
                    return index;
                }
                index++;
            }
            return 10;
        }
        public void ChangeHighScore(int index, string name, int newHighscore)
        {
            for(int i = 4; i > index; i--)
            {
                scores[i] = scores[i - 1];
                scoreNames[i] = scoreNames[i - 1];
            }
            scores[index] = newHighscore;
            scoreNames[index] = name;
        }
        public override string ToString()
        {
            string text = "";
            int number = 1;
            foreach(int i in scores)
            {
                
                text += number.ToString() + ": " + scoreNames[number-1] +  "\t\t\t" + i.ToString() + Environment.NewLine;
                number++;
            }
            return text;
        }
    }
}
