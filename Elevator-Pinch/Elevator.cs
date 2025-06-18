namespace Elevator_Pinch;

public class Elevator
{
    public int CurrentFloor { get; private set; } = 0; // ground floor is 0
    public Direction CurrentDirection { get; private set; } = Direction.Idle;
    private readonly int _maxFloor = 10; //level 10
    private readonly int _minFloor = 0;//ground floor
    private readonly List<FloorRequest> _floorRequests = new();
    private readonly List<Passenger> _passengers = new();

    public void AddFloorRequest(int floor, Direction direction)
    {
        if (!_floorRequests.Any(r => r.Floor == floor && r.Direction == direction))
        {
            Console.WriteLine($"Passenger has pressed the button {direction} on level {floor}");
            _floorRequests.Add(new FloorRequest(floor, direction));
        }
    }

    public void AddPassenger(int destinationFloor)
    {
        if (!_passengers.Any(p => p.DestinationFloor == destinationFloor))
        {
            Console.WriteLine($"Passenger has pressed the button for level {destinationFloor}");
            Console.WriteLine($"Elevator doors closing.");
            _passengers.Add(new Passenger(destinationFloor));
        }
    }

    public async Task StepAsync()
    {
        // Determine next stop
        List<int> stopList = _floorRequests.Select(r => r.Floor).Concat(_passengers.Select(p => p.DestinationFloor)).Distinct().OrderBy(f => f).ToList();
        if (stopList.Count == 0)
        {
            CurrentDirection = Direction.Idle;
            Console.WriteLine($"Elevator idle at floor {CurrentFloor} with no floor request.");
            return;
        }

        // Decide direction if idle
        if (CurrentDirection == Direction.Idle)
        {
            if (stopList.Any(f => f > CurrentFloor))
            {
                CurrentDirection = Direction.Up;
            }
            else if (stopList.Any(f => f < CurrentFloor))
            {
                CurrentDirection = Direction.Down;
            }
        }

        // Move elevator
        if (CurrentDirection == Direction.Up)
        {
            await Task.Delay(1000); // Simulate travel time
            CurrentFloor++;
        }
        else if (CurrentDirection == Direction.Down)
        {
            await Task.Delay(1000); // Simulate travel time
            CurrentFloor--;
        }

        Console.WriteLine($"Elevator arrived at floor {CurrentFloor}");

        // Open doors if needed
        bool stopped = false;
        // Drop off passengers
        List<Passenger> departing = _passengers.Where(p => p.DestinationFloor == CurrentFloor).ToList();
        if (departing.Count > 0)
        {
            stopped = true;
            foreach (Passenger p in departing)
            {
                Console.WriteLine($"Elevator stops at floor {CurrentFloor}");
            }
            _passengers.RemoveAll(p => p.DestinationFloor == CurrentFloor);
        }
        // Pick up passengers
        List<FloorRequest> requests = _floorRequests.Where(r => r.Floor == CurrentFloor /*&& r.Direction == CurrentDirection*/).ToList();
        if (requests.Count > 0)
        {
            stopped = true;
            foreach (FloorRequest r in requests)
            {
                Console.WriteLine($"Elevator stops at floor {CurrentFloor} to go {r.Direction}");
                await Task.Delay(1000);
            }
            _floorRequests.RemoveAll(r => r.Floor == CurrentFloor /*&& r.Direction == CurrentDirection*/);
        }

        if (stopped)
        {
            Console.WriteLine($"Doors open at floor {CurrentFloor} for passengers to enter or exit");
            await Task.Delay(1000); // Simulate door open time
        }

        // Change direction if no more requests in current direction
        stopList = _floorRequests.Select(r => r.Floor).Concat(_passengers.Select(p => p.DestinationFloor)).Distinct().ToList();
        if (CurrentDirection == Direction.Up && !stopList.Any(f => f > CurrentFloor))
        {
            CurrentDirection = stopList.Any(f => f < CurrentFloor) ? Direction.Down : Direction.Idle;
        }
        else if (CurrentDirection == Direction.Down && !stopList.Any(f => f < CurrentFloor))
        {
            CurrentDirection = stopList.Any(f => f > CurrentFloor) ? Direction.Up : Direction.Idle;
        }
    }

    public bool HasRequests() => _floorRequests.Count > 0 || _passengers.Count > 0;
}