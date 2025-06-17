namespace Elevator_Pinch;

class Program
{
    static void Main()
    {
        // Test case 1:
        // Passenger summons lift on the ground floor (1).
        // Once in, choose to go to level 5 (6).
        Elevator elevator = new Elevator();
        Console.WriteLine("Test 1:");
        Console.WriteLine("");
        elevator.AddFloorRequest(1, Direction.Up);
        while (elevator.CurrentFloor != 1)
        {
            elevator.Step(); // Ensure elevator is at ground
        }
        elevator.Step(); // Pick up
        elevator.AddPassenger(6); //level 5
        while (elevator.HasRequests())
        {
            elevator.Step();
        }
        Console.WriteLine("Hit any key to continue to test 2");
        Console.ReadKey();


        // Test case 2:
        // Passenger summons lift on level 6 to go down.
        // Passenger on level 4 summons the lift to go down.
        // They both choose level 1.
        elevator = new Elevator();
        Console.WriteLine("Test 2");
        elevator.AddFloorRequest(6, Direction.Down);
        elevator.AddFloorRequest(4, Direction.Down);
        while (elevator.CurrentFloor != 7) elevator.Step(); // Go to 6
        elevator.Step(); // Pick up at 6
        elevator.AddPassenger(1);
        while (elevator.CurrentFloor != 5) elevator.Step(); // Go to 4
        elevator.Step(); // Pick up at 4
        elevator.AddPassenger(2);//level 1
        while (elevator.HasRequests()) elevator.Step();

        Console.WriteLine("Hit any key to continue to test 3");
        Console.ReadKey();

        // Test case 3:
        // Passenger 1 summons lift to go up from level 2.
        // Passenger 2 summons lift to go down from level 4.
        // Passenger 1 chooses to go to level 6.
        // Passenger 2 chooses to go to ground floor
        elevator = new Elevator();
        Console.WriteLine("Test 3");
        elevator.AddFloorRequest(2, Direction.Up);
        elevator.AddFloorRequest(4, Direction.Down);
        while (elevator.CurrentFloor != 2) elevator.Step();
        elevator.Step(); // Pick up at 2
        elevator.AddPassenger(6);
        while (elevator.CurrentFloor != 4) elevator.Step();
        elevator.Step(); // Pick up at 4
        elevator.AddPassenger(1);
        while (elevator.HasRequests()) elevator.Step();

        Console.WriteLine("Hit any key to continue to test 4");
        Console.ReadKey();

        // Test case 4:
        // Passenger 1 summons lift to go up from Ground.
        // They choose level 5.
        // Passenger 2 summons lift to go down from level 4.
        // Passenger 3 summons lift to go down from level 10.
        // Passengers 2 and 3 choose to travel to ground floor.
        elevator = new Elevator();
        Console.WriteLine("Test 4");
        elevator.AddFloorRequest(1, Direction.Up);
        elevator.AddFloorRequest(4, Direction.Down);
        elevator.AddFloorRequest(10, Direction.Down);
        while (elevator.CurrentFloor != 1) elevator.Step();
        elevator.Step(); // Pick up at 1
        elevator.AddPassenger(5);
        while (elevator.CurrentFloor != 4) elevator.Step();
        elevator.Step(); // Pick up at 4
        elevator.AddPassenger(1);
        while (elevator.CurrentFloor != 10) elevator.Step();
        elevator.Step(); // Pick up at 10
        elevator.AddPassenger(1);
        while (elevator.HasRequests()) elevator.Step();
        Console.WriteLine();
    }
}