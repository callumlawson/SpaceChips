using UnityEngine;

internal class Engine : Component
{
    private readonly Wire deltaXInput;
    private readonly Wire deltaYInput;
    private readonly ShipModel shipModel;

    public Engine(Simulation simulation, ShipModel shipModel, Wire deltaXInput, Wire deltaYInput) : base(simulation)
    {
        this.deltaYInput = deltaYInput;
        this.deltaXInput = deltaXInput;
        this.shipModel = shipModel;
    }

    public override void OnClockEdge()
    {
        shipModel.PositionX += deltaXInput.SignalValue;
        shipModel.PositionY += deltaYInput.SignalValue;
    }
}