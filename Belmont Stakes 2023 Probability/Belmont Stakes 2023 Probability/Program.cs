using Belmont_Stakes_2023_Probability.Models;
using MathNet.Numerics;

internal class Program
{
    private static void Main()
    {
        while (true)
        {
            RunSimulation();
        }
    }

    private static void RunSimulation()
    {
        double capitalValue = ReadNumberInput("Starting Capital Amount:");
        Capital capital = new Capital(capitalValue);

        BallBox ballBox = InitializeBallBox();
        CostEvaluator costEvaluator = InitializeCostEvaluator();

        int drawingsCount = (int)ReadNumberInput("Number of Drawings:");

        double drawingCost;
        BallColor ballColor;
        for (int i = 0; i < drawingsCount; i++)
        {
            ballColor = ballBox.DrawBall();
            drawingCost = costEvaluator.EvaluateDrawCost(ballColor);
            capital.CurrentCapital += drawingCost;
        }

        PrintResults(capital, costEvaluator, ballBox, drawingsCount);
    }

    private static BallBox InitializeBallBox()
    {
        BallBox ballBox = new BallBox();
        ballBox.RedBallCount = (int)ReadNumberInput("Number of Red balls:");
        ballBox.YellowBallCount = (int)ReadNumberInput("Number of Yellow balls:");
        ballBox.BlueBallCount = (int)ReadNumberInput("Number of Blue balls:");
        ballBox.PurpleBallCount = (int)ReadNumberInput("Number of Purple balls:");
        ballBox.GreenBallCount = (int)ReadNumberInput("Number of Green balls:");
        ballBox.FillBox();
        return ballBox;
    }

    private static CostEvaluator InitializeCostEvaluator()
    {
        CostEvaluator costEvaluator = new CostEvaluator();
        costEvaluator.DrawCharge = ReadNumberInput("Draw Charge:");
        costEvaluator.Red_Cost = ReadNumberInput("Red Ball Draw Cost:");
        costEvaluator.Yellow_Cost = ReadNumberInput("Yellow Ball Draw Cost:");
        costEvaluator.Blue_Cost = ReadNumberInput("Blue Ball Draw Cost:");
        costEvaluator.Purple_Cost = ReadNumberInput("Purple Ball Draw Cost:");
        costEvaluator.Green_Cost = ReadNumberInput("Green Ball Draw Cost:");
        return costEvaluator;
    }

    private static void PrintResults(
        Capital capital, CostEvaluator costEvaluator, BallBox ballBox, double drawCount)
    {
        PrintSerperator();

        Print("Ball Facts:");
        Print();
        Print($"     Red: {ballBox.RedBallCount} ({ballBox.RedBallPercent.Round(4)}%)");
        Print();
        Print($"          Number Drawn: {ballBox.RedBallDrawCount} ({(((double)ballBox.RedBallDrawCount / drawCount) * 100).Round(4)}%)");
        Print($"          Charges Total: ${ballBox.RedBallDrawCount * costEvaluator.DrawCharge}");
        Print($"          Cost Total: ${ballBox.RedBallDrawCount * costEvaluator.Red_Cost}");
        Print($"          Total Capital Effect: ${(ballBox.RedBallDrawCount * costEvaluator.DrawCharge) - (ballBox.RedBallDrawCount * costEvaluator.Red_Cost)}");
        Print();
        Print($"     Yellow: {ballBox.YellowBallCount} ({ballBox.YellowBallPercent.Round(4)}%)");
        Print();
        Print($"          Number Drawn: {ballBox.YellowBallDrawCount} ({(((double)ballBox.YellowBallDrawCount / drawCount) * 100).Round(4)}%)");
        Print($"          Charges Total: ${ballBox.YellowBallDrawCount * costEvaluator.DrawCharge}");
        Print($"          Cost Total: ${ballBox.YellowBallDrawCount * costEvaluator.Yellow_Cost}");
        Print($"          Total Capital Effect: ${(ballBox.YellowBallDrawCount * costEvaluator.DrawCharge) - (ballBox.YellowBallDrawCount * costEvaluator.Yellow_Cost)}");
        Print();
        Print($"     Blue: {ballBox.BlueBallCount} ({ballBox.BlueBallPercent.Round(4)}%)");
        Print();
        Print($"          Number Drawn: {ballBox.BlueBallDrawCount} ({(((double)ballBox.BlueBallDrawCount / drawCount) * 100).Round(4)}%)");
        Print($"          Charges Total: ${ballBox.BlueBallDrawCount * costEvaluator.DrawCharge}");
        Print($"          Cost Total: ${ballBox.BlueBallDrawCount * costEvaluator.Blue_Cost}");
        Print($"          Total Capital Effect: ${(ballBox.BlueBallDrawCount * costEvaluator.DrawCharge) - (ballBox.BlueBallDrawCount * costEvaluator.Blue_Cost)}");
        Print();
        Print($"     Purple: {ballBox.PurpleBallCount} ({ballBox.PurpleBallPercent.Round(4)}%)");
        Print();
        Print($"          Number Drawn: {ballBox.PurpleBallDrawCount} ({(((double)ballBox.PurpleBallDrawCount / drawCount)*100).Round(4)}%)");
        Print($"          Charges Total: ${ballBox.PurpleBallDrawCount * costEvaluator.DrawCharge}");
        Print($"          Cost Total: ${ballBox.PurpleBallDrawCount * costEvaluator.Purple_Cost}");
        Print($"          Total Capital Effect: ${(ballBox.PurpleBallDrawCount * costEvaluator.DrawCharge) - (ballBox.PurpleBallDrawCount * costEvaluator.Purple_Cost)}");
        Print();
        Print($"     Green: {ballBox.GreenBallCount} ({ballBox.GreenBallPercent.Round(4)}%)");
        Print();
        Print($"          Number Drawn: {ballBox.GreenBallDrawCount} ({(((double)ballBox.GreenBallDrawCount / drawCount)*100).Round(4)}%)");
        Print($"          Charges Total: ${ballBox.GreenBallDrawCount * costEvaluator.DrawCharge}");
        Print($"          Cost Total: ${ballBox.GreenBallDrawCount * costEvaluator.Green_Cost}");
        Print($"          Total Capital Effect: ${(ballBox.GreenBallDrawCount * costEvaluator.DrawCharge) - (ballBox.GreenBallDrawCount * costEvaluator.Green_Cost)}");
        Print();
        Print($"     Total Ball Count: {ballBox.TotalBallCount}");

        PrintSerperator();

        Print("Capital Facts:");
        Print($"     Initial Capital: {capital.InitialCapital}");
        Print($"     Highest Capital: {capital.MaxCapital}");
        Print($"     Lowest Capital: {capital.MinCapital}");
        Print($"     Final Capital: {capital.CurrentCapital}");
        Print();
        Print($"Total Capital Change: {capital.TotalCapitalChange}");

        PrintSerperator();

        Print();
        Print();
        Print();
        Print();
        Print();
        Print();
        Print();
        Print();
    }

    public static void Print(string input = "") => Console.WriteLine(input);

    private static double ReadNumberInput(string request)
    {
        Console.WriteLine(request);
        var input = Console.ReadLine();
        Console.WriteLine();
        double.TryParse(input, out double parsedInt);
        return parsedInt;
    }

    public static void PrintSerperator()
    {
        Print();
        Print();
        Print("******************************************************************************");
        Print();
        Print();
    }

}