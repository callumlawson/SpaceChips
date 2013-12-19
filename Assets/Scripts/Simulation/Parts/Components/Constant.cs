
namespace Assets.Scripts.Simulation.Parts.Components
{
    class Constant : Component
    {
        private readonly float constantValue;
        private readonly Wire constantValueOuput;

        public Constant(Simulation simulation, float constantValue, Wire constantValueOuput) : base(simulation)
        {
            this.constantValueOuput = constantValueOuput;
            this.constantValue = constantValue;
        }

        public override void OnClockEdge()
        {
            constantValueOuput.SignalValue = constantValue;
        }
    }
}
