using Model;
using NUnit.Framework;

namespace TDDTesting
{
	internal class RoverTest
	{
		[Test]
		public void TestMoveForwardOnce()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("F");
			Assert.That(rover.Location, Is.EqualTo((0, 1)));
		}

		[Test]
		public void TestMoveForwardTwice()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("FF");
			Assert.That(rover.Location, Is.EqualTo((0, 2)));
		}

		[Test]
		public void TestMoveBackwardOnce()
		{
			Rover rover = new Rover((0,0), 'N');
			rover.Run("B");
			Assert.That(rover.Location, Is.EqualTo((0, -1)));
		}

		[Test]
		public void TestTurnRightOnce()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("R");
			Assert.That(rover.Direction, Is.EqualTo('E'));
		}

		[Test]
		public void TestTurnRightTwice()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("RR");
			Assert.That(rover.Direction, Is.EqualTo('S'));
		}

		[Test]
		public void TestTurnLeftOnce()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("L");
			Assert.That(rover.Direction, Is.EqualTo('W'));
		}

		[Test]
		public void TestTurnLeftTwice()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("LL");
			Assert.That(rover.Direction, Is.EqualTo('S'));
		}

		[Test]
		public void TestTurnLeftTurnRight()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("RL");
			Assert.That(rover.Direction, Is.EqualTo('N'));
		}

		[Test]
		public void TestTurnRightMoveForward()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("RF");
			Assert.That(rover.Location, Is.EqualTo((1, 0)));
		}

		[Test]
		public void TestTurnLeftMoveForward()
		{
			Rover rover = new Rover((0, 0), 'N');
			rover.Run("LF");
			Assert.That(rover.Location, Is.EqualTo((-1, 0)));
		}

		[Test]
		public void TestMoveForwardStartingSouth()
		{
			Rover rover = new Rover((0, 0), 'S');
			rover.Run("F");
			Assert.That(rover.Location, Is.EqualTo((0, -1)));
		}

		[Test]
		public void TestMoveBackwardStartingEast()
		{
			Rover rover = new Rover((0, 0), 'E');
			rover.Run("B");
			Assert.That(rover.Location, Is.EqualTo((-1, 0)));
		}

		[Test]
		public void TestMoveBackwardStartingSouth()
		{
			Rover rover = new Rover((0, 0), 'S');
			rover.Run("B");
			Assert.That(rover.Location, Is.EqualTo((0, 1)));
		}

		[Test]
		public void TestMoveBackwardStartingWest()
		{
			Rover rover = new Rover((0, 0), 'W');
			rover.Run("B");
			Assert.That(rover.Location, Is.EqualTo((1, 0)));
		}

		[Test]
		public void TestSequenceOfInstruction()
		{
			Rover rover = new Rover((3, 5), 'S');
			rover.Run("LFFRBB");
			Assert.That(rover.Location, Is.EqualTo((5, 7)));
		}

        [Test]
		public void TestTurnRighFromWest()
        {
			Rover rover = new Rover((0, 0), 'W');
			rover.Run("R");
			Assert.That(rover.Direction, Is.EqualTo('N'));
		}
	}
}
