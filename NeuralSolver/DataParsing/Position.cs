using System;

namespace NeuralSolver{
	internal class Position{
		public double X { get; set; }
		public double Y { get; set; }

		public static Position operator -(Position left, Position right){
			return new Position(){
				X = left.X - right.X,
				Y = left.Y - right.Y,
			};
		}

		public override string ToString(){
			return String.Format("X: {0}, Y: {1}", X, Y);
		}
	}
}