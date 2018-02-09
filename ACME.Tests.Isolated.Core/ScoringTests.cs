using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using ACME.Domain;

namespace ACME.Tests.Isolated.Core
{
    [TestClass]
    public class ScoringTests
    {

        [TestMethod]
        public void parse_only_number()
        {
            string inputData = "111";
            ICollection actual = ScoreBuilder.ParseScore(inputData);
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1 }, actual);
        }

        [TestMethod]
        public void parse_only_strike()
        {
            string inputData = "X";
            ICollection actual = ScoreBuilder.ParseScore(inputData);
            CollectionAssert.AreEqual(new List<int> { 10 }, actual);
        }

        [TestMethod]
        public void parse_score_with_spare()
        {
            string inputData = "X9/-";
            ICollection actual = ScoreBuilder.ParseScore(inputData);
            CollectionAssert.AreEqual(new List<int> { 10, 9, 1, 0 }, actual);
        }


        [TestMethod]
        public void calculate_score_with_simple_ones()
        {
            var rolls = new List<int> { 1, 1, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0};

            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, score);
        }

        [TestMethod]
        public void calculate_score_with_spares()
        {   // 12
            var rolls = new List<int> { 9, 1, 1, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0};
            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 11, 12, 12, 12, 12, 12, 12, 12, 12, 12 }, score);
        }

        [TestMethod]
        public void calculate_score_with_strikes()
        {
            // 14
            var rolls = new List<int> { 10, 1, 1, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0};
            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 12, 14, 14, 14, 14,
                                                      14, 14, 14, 14, 14 }, score);
        }

        [TestMethod]
        public void calculate_score_with_double_strikes()
        {
            // 32
            var rolls = new List<int> { 10, 10, 1, 1, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0};
            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 21, 33, 35, 35, 35,
                                                      35, 35, 35, 35, 35 }, score);
        }

        [TestMethod]
        public void calculate_score_at_tenth_frame_with_spare()
        {
            // 12
            var rolls = new List<int> { 0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        5, 5, 1};
            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 0, 0, 0, 0, 0,
                                                      0, 0, 0, 0, 11 }, score);
        }

        [TestMethod]
        public void calculate_score_at_tenth_frame_with_strike()
        {
            var rolls = new List<int> { 0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        0, 0, 0, 0, 0, 0,
                                        10, 10, 10};
            var score = ScoreBuilder.CalculateScore(rolls);
            CollectionAssert.AreEqual(new List<int> { 0, 0, 0, 0, 0,
                                                      0, 0, 0, 0, 30 }, score);
        }
    }
}
