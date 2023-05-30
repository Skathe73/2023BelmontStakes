namespace Belmont_Stakes_2023_Probability.Models
{
    public sealed class BallBox
    {
        public int RedBallCount { get; set; }
        public int YellowBallCount { get; set; }
        public int BlueBallCount { get; set; }
        public int PurpleBallCount { get; set; }
        public int GreenBallCount { get; set; }

        public int TotalBallCount =>
            (RedBallCount + YellowBallCount + BlueBallCount + PurpleBallCount + GreenBallCount);

        public double RedBallPercent => ((double)RedBallCount / (double)TotalBallCount) * 100;
        public double YellowBallPercent => ((double)YellowBallCount / (double)TotalBallCount) * 100;
        public double BlueBallPercent => ((double)BlueBallCount / (double)TotalBallCount) * 100;
        public double PurpleBallPercent => ((double)PurpleBallCount / (double)TotalBallCount) * 100;
        public double GreenBallPercent => ((double)GreenBallCount / (double)TotalBallCount) * 100;

        public List<BallColor> Balls { get; set; } = new List<BallColor>();

        public double RedBallDrawCount { get; private set; } = 0;
        public double YellowBallDrawCount { get; private set; } = 0;
        public double BlueBallDrawCount { get; private set; } = 0;
        public double PurpleBallDrawCount { get; private set; } = 0;
        public double GreenBallDrawCount { get; private set; } = 0;

        public void FillBox()
        {
            FillColor(BallColor.Red, RedBallCount);
            FillColor(BallColor.Yellow, YellowBallCount);
            FillColor(BallColor.Blue, BlueBallCount);
            FillColor(BallColor.Purple, PurpleBallCount);
            FillColor(BallColor.Green, GreenBallCount);
        }

        private void FillColor(BallColor color, int ballCount)
        {
            for (int i = 0; i < ballCount; i++)
            {
                Balls.Add(color);
            }
        }

        public BallColor DrawBall()
        {
            Random random = new();
            int draw = random.Next(1, Balls.Count);
            BallColor ballColor = Balls[draw];
            RecordBallDraw(ballColor);
            return ballColor;
        }

        public void RecordBallDraw(BallColor drawnColor)
        {
            switch (drawnColor)
            {
                case BallColor.Red:
                    RedBallDrawCount++;
                    break;
                case BallColor.Yellow:
                    YellowBallDrawCount++;
                    break;
                case BallColor.Blue:
                    BlueBallDrawCount++;
                    break;
                case BallColor.Purple:
                    PurpleBallDrawCount++;
                    break;
                case BallColor.Green:
                    GreenBallDrawCount++;
                    break;
            }
        }

    }
}
