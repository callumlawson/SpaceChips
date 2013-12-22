using Debug = UnityEngine.Debug;

    class Engine : Component
    {
        private ShipModel shipModel;
        private Wire deltaXInput;
        private Wire deltaYInput;

        public Engine(Simulation simulation, ShipModel shipModel, Wire deltaXInput, Wire deltaYInput) : base(simulation)
        {
            this.deltaYInput = deltaYInput;
            this.deltaXInput = deltaXInput;
            this.shipModel = shipModel;
        }

        public override void OnClockEdge()
        {
            Debug.Log("position updated");
            shipModel.PositionX += deltaXInput.SignalValue;
            shipModel.PositionY += deltaYInput.SignalValue;
        }
    }
