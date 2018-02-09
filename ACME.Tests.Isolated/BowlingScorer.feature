Feature: BowlingScorer
	* strike are 10 pus the next 2 rolls

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Bowling game with all 1's
	Given I have bowled 10 frames
	And Each frame count has a score of 2
	When I total the score
	Then the result should be 20
