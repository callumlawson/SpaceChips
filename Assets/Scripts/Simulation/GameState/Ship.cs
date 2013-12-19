using Assets.Scripts.Simulation.Parts;
using Assets.Scripts.Simulation.Parts.Components;

namespace Assets.Scripts.Simulation.GameState
{
    class Ship
    {
        public float PositionX, PositionY;
        private readonly Simulation simulation = new Simulation();
        private World world;

        public Ship(World world)
        {
            this.world = world;
            BuildComponents();
            simulation.Start();
        }

        private void BuildComponents()
        {
            var rangeWire = new Wire();
            var bearingWire = new Wire();
            var deltaXWire = new Wire();
            var deltaYWire = new Wire();

            new Scanner(simulation, world, rangeWire, bearingWire);
            new Probe(simulation, "Range", rangeWire);
            new Probe(simulation, "Bearing", bearingWire);
            new Constant(simulation, 0.005f, deltaXWire);
            new Constant(simulation, 0.001f, deltaYWire);
            new Engine(simulation, this, deltaXWire, deltaYWire);
        }

        public void Kill()
        {
            simulation.Stop();
        }
    }
}