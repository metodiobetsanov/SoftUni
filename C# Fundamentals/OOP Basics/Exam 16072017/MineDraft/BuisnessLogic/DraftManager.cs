using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private string mode;
    private double totalEnergyStored;
    private double totalMinesOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.mode = "Full";
        this.totalEnergyStored = 0;
        this.totalMinesOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {

        double dayEnergyProv = providers.Sum(x => x.EnergyOutput);
        totalEnergyStored += dayEnergyProv;
        double dayEnergyReq;
        double dayOreMined;

        if (mode == "Full")
        {
            dayEnergyReq = harvesters.Sum(x => x.EnergyRequirement);
            dayOreMined = harvesters.Sum(x => x.OreOutput);
        }
        else if(mode == "Half")
        {
            dayEnergyReq = harvesters.Sum(x => x.EnergyRequirement) * 0.6;
            dayOreMined = harvesters.Sum(x => x.OreOutput) * 0.5;
        }
        else
        {
            dayEnergyReq = 0;
            dayOreMined = 0;
        }
        double realMined = 0;
        if (totalEnergyStored >= dayEnergyReq)
        {
            totalMinesOre += dayOreMined;
            totalEnergyStored -= dayEnergyReq;
            realMined = dayOreMined;
        }

        return $"A day has passed.{Environment.NewLine}Energy Provided: {dayEnergyProv}{Environment.NewLine}Plumbus Ore Mined: {realMined}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Unit unit = (Unit)harvesters.FirstOrDefault(x => x.Id == id) ?? providers.FirstOrDefault(x => x.Id == id);
        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {totalEnergyStored}{Environment.NewLine}Total Mined Plumbus Ore: {totalMinesOre}";
    }

}

