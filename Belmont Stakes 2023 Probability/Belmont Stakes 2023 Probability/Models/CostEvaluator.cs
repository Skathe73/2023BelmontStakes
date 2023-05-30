namespace Belmont_Stakes_2023_Probability.Models
{
    public class CostEvaluator
    {
        public double DrawCharge { get; set; }

        public double Red_Cost { get; set; }
        public double Yellow_Cost { get; set; }
        public double Blue_Cost { get; set; }
        public double Purple_Cost { get; set; }
        public double Green_Cost { get; set; }

        public double EvaluateDrawCost(BallColor ballColor)
        {
            var cost = ballColor switch
            {
                BallColor.Red => Red_Cost,
                BallColor.Yellow => Yellow_Cost,
                BallColor.Blue => Blue_Cost,
                BallColor.Purple => Blue_Cost,
                BallColor.Green => Green_Cost,
                _ => 0,
            };
            return DrawCharge - cost;
        }

    }
}
