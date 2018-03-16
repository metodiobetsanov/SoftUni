using System;

    public abstract class Provider : Unit
    {
    const double maxEnergyOutput = 10_000;

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value < 0 || value > maxEnergyOutput)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public override string ToString()
    {
        return $"{Type} Provider - {Id}{Environment.NewLine}Energy Output: {energyOutput}";
    }
}

