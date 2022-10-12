// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var game = new BowlingGame.BowlingGame();
var random = new Random();
var result = 0;
foreach(var frame in game.Frames)
{
    int noOfPinsDropped = random.Next(0, 11);
    game.Roll(noOfPinsDropped);
    random = new Random();
    game.Roll(random.Next(0, 10 - noOfPinsDropped));
    result += game.Score();
}

Console.WriteLine(result);

