using System;

public abstract class Harvester : Unit
{
    const double maxEnergyRequirement = 20_000;

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value >= maxEnergyRequirement)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    protected Harvester(string id, double oreOutput, double energyRequirement) 
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}{Environment.NewLine}Ore Output: {oreOutput}{Environment.NewLine}Energy Requirement: {energyRequirement}";
    }
}

