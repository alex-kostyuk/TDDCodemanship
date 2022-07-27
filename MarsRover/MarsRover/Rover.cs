namespace Model
{
	public class Rover
	{
		private string directions = "NESW";
		public char Direction { get; private set; }

		public (int x, int y) Location { get; private set; }

		public Rover((int, int) location, char direction)
		{
			this.Location = location;
			this.Direction = direction;
		}

		public void Run(string command)
		{
            char currentDirection = Direction;
			int pathY = 0;
			int pathX = 0;
			foreach (var step in command)
            {
                DetectLocationChanges(ref pathY, ref pathX, step, currentDirection);
                currentDirection = ChangeDirection(step, currentDirection);
            }
            Direction = currentDirection;
            Location = (Location.x + pathX, Location.y + pathY);
		}

        private char ChangeDirection(char step, char direction)
        {
            char result = direction;
            var currentIndex = directions.IndexOf(direction);
            if (step == 'R')
            {
                result = directions[currentIndex == 3 ? 0 : currentIndex + 1];
            }
            if (step == 'L')
            {
                result = directions[currentIndex == 0 ? 3 : currentIndex - 1];
            }
            return result;
        }

        private void DetectLocationChanges(ref int pathY, ref int pathX, char step, char direction)
        {
            if (step == 'F' || step == 'B')
            {
                switch (direction)
                {
                    case 'N':
                        pathY += step == 'F' ? 1 : -1;
                        break;
                    case 'E':
                        pathX += step == 'F' ? 1 : -1;
                        break;
                    case 'S':
                        pathY += step == 'F' ? -1 : 1;
                        break;
                    case 'W':
                        pathX += step == 'F' ? -1 : 1;
                        break;
                }
            }
        }
    }
}