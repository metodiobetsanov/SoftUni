using System;

public class StartUp
{
    static void Main()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        Engine engine = new Engine(raceTower);
        engine.Run();
    }
}
