namespace Elevator_Pinch;

class Program
{
    static async Task Main()
    {
        // Test case 1:
        // Passenger summons lift on the ground floor (0).
        // Once in, choose to go to level 5.
        Elevator elevator = new Elevator();
        Console.WriteLine("Test 1:");
        Console.WriteLine("");
        Console.WriteLine("Elevator is at ground level (0)");
        elevator.AddFloorRequest(0, Direction.Up);
        await Task.Delay(1000);
        await elevator.StepAsync(); // Pick up
        elevator.AddPassenger(5); //level 5
        await Task.Delay(1000);
        while (elevator.HasRequests())
        {
            await elevator.StepAsync();
        }
        Console.WriteLine("Hit any key to continue to test 2");
        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("");

        // Test case 2:
        // Passenger summons lift on level 6 to go down.
        // Passenger on level 4 summons the lift to go down.
        // They both choose level 1.
        elevator = new Elevator();
        Console.WriteLine("Test 2");
        Console.WriteLine("");
        Console.WriteLine("Elevator is at ground level (0)");
        elevator.AddFloorRequest(6, Direction.Down);
        elevator.AddFloorRequest(4, Direction.Down);
        await Task.Delay(1000);
        while (elevator.CurrentFloor != 6) await elevator.StepAsync(); // Go to 6
        await elevator.StepAsync(); // Pick up at 6
        elevator.AddPassenger(1);
        while (elevator.CurrentFloor != 4) await elevator.StepAsync(); // Go to 4
        await elevator.StepAsync(); // Pick up at 4
        elevator.AddPassenger(1);//level 1
        while (elevator.HasRequests()) await elevator.StepAsync();

        Console.WriteLine("Hit any key to continue to test 3");
        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("");

        // Test case 3:
        // Passenger 1 summons lift to go up from level 2.
        // Passenger 2 summons lift to go down from level 4.
        // Passenger 1 chooses to go to level 6.
        // Passenger 2 chooses to go to ground floor
        elevator = new Elevator();
        Console.WriteLine("Test 3");
        Console.WriteLine("");
        Console.WriteLine("Elevator is at ground level (0)");
        elevator.AddFloorRequest(2, Direction.Up);
        elevator.AddFloorRequest(4, Direction.Down);
        while (elevator.CurrentFloor != 2)
        {
            await elevator.StepAsync();
        }
        await elevator.StepAsync(); // Pick up at 2
        elevator.AddPassenger(6);
        while (elevator.CurrentFloor != 4)
        {
            await elevator.StepAsync();
        }
        await elevator.StepAsync(); // Pick up at 4
        elevator.AddPassenger(0);
        while (elevator.HasRequests())
        {
            await elevator.StepAsync();
        }

        Console.WriteLine("Hit any key to continue to test 4");
        Console.ReadKey();
        Console.WriteLine("");
        Console.WriteLine("");

        // Test case 4:
        // Passenger 1 summons lift to go up from ground floor.
        // They choose level 5.
        // Passenger 2 summons lift to go down from level 4.
        // Passenger 3 summons lift to go down from level 10.
        // Passengers 2 and 3 choose to travel to ground floor.
        elevator = new Elevator();
        Console.WriteLine("Test 4");
        Console.WriteLine("");
        Console.WriteLine("Elevator is at ground level (0)");
        elevator.AddFloorRequest(0, Direction.Up);
        elevator.AddFloorRequest(4, Direction.Down);
        elevator.AddFloorRequest(10, Direction.Down);
        while (elevator.CurrentFloor != 0)
        {
            await elevator.StepAsync();
        }
        await elevator.StepAsync(); // Pick up at 0
        elevator.AddPassenger(5);
        while (elevator.CurrentFloor != 4)
        {
            await elevator.StepAsync();
        }
        await elevator.StepAsync(); // Pick up at 4
        elevator.AddPassenger(0);
        while (elevator.CurrentFloor != 10)
        {
            await elevator.StepAsync();
        }
        await elevator.StepAsync(); // Pick up at 10
        elevator.AddPassenger(0);
        while (elevator.HasRequests()) await elevator.StepAsync();
        Console.WriteLine();
    }
}