using System;
using System.Collections.Generic;
using System.Text;

    public class HarvesterFactory
    {
    public Harvester CreateHarvester(List<string> args)
    {
        var type = args[0];
        var id = args[1];
        var oreOutput = double.Parse(args[2]);
        var energyrEquirment = double.Parse(args[3]);

        switch (type)
        {
            case "Hammer": return new HammerHarvester(id, oreOutput, energyrEquirment);
            case "Sonic": return new SonicHarvester(id, oreOutput, energyrEquirment, int.Parse(args[4]));
            default:
                throw new ArgumentException();
        }
    }
    }

