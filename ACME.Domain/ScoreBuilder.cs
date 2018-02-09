using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACME.Domain
{
    public class ScoreBuilder
    {
        public static List<int> ParseScore(string inputData)
        {
            var symbols = inputData.ToCharArray();
            var numbers = new List<int>();

            for (int i = 0; i < symbols.Length; i++)
            {
                //var character = int.Parse(symbols[i].ToString();
                if ( symbols[i].ToString() == "X")
                {
                    numbers.Add(10);
                }

                else if (symbols[i].ToString() == "/")
                {
                    var tenMinusPreviousNumber = 10 - numbers.Last();
                    numbers.Add(tenMinusPreviousNumber);
                }

                else if (symbols[i].ToString() == "-")
                {
                    numbers.Add(0);
                }
                else
                {
                    numbers.Add(int.Parse(symbols[i].ToString()));
                }
                
            }

            return numbers;
        }

        public static List<int> CalculateScore(List<int> rolls)
        {
            var rollCount = 0;
            var frames = new List<int>();

            for (int fi = 0; fi < 10; fi++)
            {
                var first = rolls[rollCount];
                var second = rolls[rollCount + 1];
                var previous_frame = frames.Count > 0 ? frames.Last() : 0;
                
                // If we are not on the last frame
                if (frames.Count != 10)
                {
                    // Strikes
                    if (first == 10)
                    {
                        var frameScore = previous_frame + first + second + rolls[rollCount + 2];
                        frames.Add(frameScore);
                        rollCount += 1;

                    }
                    // Spares
                    else if (first + second == 10)
                    {

                        var frameScore = previous_frame + first + second + rolls[rollCount + 2];
                        frames.Add(frameScore);
                        rollCount += 2;

                    }
                    // Regular Scoring
                    else
                    {
                        frames.Add(previous_frame + first + second);
                        rollCount += 2;
                    }
                }
                else
                {   //When we get to the last frame
                    if (first == 10 || first + second == 10)
                    {
                        var frameScore = previous_frame + first + second + rolls[rollCount + 2];
                        frames.Add(frameScore);
                    }
                    
                }
                
            };

            return frames;
        }
    }
}
