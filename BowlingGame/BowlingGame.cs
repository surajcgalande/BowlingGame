using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingGame
    {
        private List<Frame> frames;
        private static int MAX_FRAMES = 10;
        private static int MAX_PINS = 10;
        private int frameCounter = 0;

        public BowlingGame()
        {
            frames = new List<Frame>(MAX_FRAMES);

            for (int i = 0; i < MAX_FRAMES; i++)
            {
                frames.Add(new Frame(i + 1));
            }
        }

        public List<Frame> Frames { get { return frames; } }

        public void Roll(int noOfPinsDropped)
        {
            if (noOfPinsDropped > MAX_PINS)
                throw new Exception("Pins should be less than 10");

            Frame frame = GetFrame();

            if (frame == null)
                throw new Exception("All attempts exhausted.");

            frame.SetScore(noOfPinsDropped);

            if (IsBonusFrame(frame))
            {
                Frame prev = GetPreviousFrame();
                // restrict to one attempt, when last frame was spare
                if (prev.IsSpare() || prev.IsStrike())
                {
                    frame.LimitToOneAttempt();
                }
            }
        }

        private Frame GetFrame()
        {
            Frame frame = GetCurrentFrame();

            if (frame.IsDone())
            {
                // new bonus frame
                if (IsLastFrame(frame) && (frame.IsSpare() || frame.IsStrike()))
                {
                    Frame bonus = new Frame(11);
                    frames.Add(bonus);
                    frameCounter++;
                    return bonus;
                }
                if(!IsBonusFrame(frame))
                    frameCounter++;
                frame = GetCurrentFrame();
            }

            return frame;
        }

        public int Score()
        {
            int score;

            if (frameCounter == 0)
            {
                Frame curr = GetCurrentFrame();
                return curr.Score();
            }
            else
            {
                Frame curr = GetCurrentFrame();
                Frame prev = GetPreviousFrame();

                if (IsBonusFrame(curr))
                    return prev.Score() + curr.Score();

                score = curr.Score();

                if (prev.IsSpare())
                    score += (prev.Score() + curr.GetFirstScore());

                if (prev.IsStrike())
                    score += (prev.Score() + curr.GetFirstScore() + curr.GetSecondScore());
            }

            return score;
        }

        private Frame GetPreviousFrame()
        {
            return frames[frameCounter - 1];
        }

        private Frame GetCurrentFrame()
        {
            return frames[frameCounter];
        }

        private bool IsBonusFrame(Frame frame)
        {
            return frame.Id == 11;
        }

        private bool IsLastFrame(Frame frame)
        {
            return frame.Id == 10;
        }
    }
}
