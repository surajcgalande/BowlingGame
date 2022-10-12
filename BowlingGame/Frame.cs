using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Frame
    {        
        private static int MAX_PINS = 10;
        private static int MAX_ATTEMPTS_PER_FRAME = 2;
        private int[] scores = new int[MAX_ATTEMPTS_PER_FRAME];
        private int noOfPinsLeft = 10;
        private int noOfAttempts = 0;
        private bool isSpare = false;
        private bool isStrike = false;

        public Frame(int _id)
        {
            Id = _id;
        }

        public int Id { get; set; }

        public bool IsSpare() { return isSpare; }

        public bool IsStrike() { return isStrike; }

        public bool IsDone() { return noOfAttempts == MAX_ATTEMPTS_PER_FRAME; }

        public void SetScore(int score)
        {
            scores[noOfAttempts++] = score;
            noOfPinsLeft -= score;            

            //If it is Spare or Strike
            if (noOfPinsLeft == 0)
            {
                //If it is a Strike
                if (noOfAttempts == 1)
                    isStrike = true;

                //If it is a Spare
                if (noOfAttempts == MAX_ATTEMPTS_PER_FRAME && !isStrike)
                    isSpare = true;                
            }
        }

        public void LimitToOneAttempt()
        {
            scores[1] = 0;
            noOfAttempts++;
        }

        public int Score() { return scores[0] + scores[1]; }

        public int GetFirstScore() { return scores[0]; }

        public int GetSecondScore() { return scores[1]; }
    }
}
