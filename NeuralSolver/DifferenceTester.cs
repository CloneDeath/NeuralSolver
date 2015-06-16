using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralSolver
{
	class DifferenceTester
	{
		private readonly PositionPredictor _predictor;

		public DifferenceTester(PositionPredictor predictor){
			_predictor = predictor;
		}

		public double GetDifference(TestSet testSet){
			double difference = 0;

			for (int i = _predictor.HistorySize - 1; i < testSet.Count - 1; i++){
				List<Position> history = new List<Position>();

				for (int j = 0; j < _predictor.HistorySize; j++){
					history.Add(testSet[i - j]);
				}

				var next = testSet[i + 1];
				var prediction = _predictor.GetPrediction(history.ToArray());
				var diff = prediction - next;

				difference += Math.Sqrt(Math.Pow(diff.X, 2) + Math.Pow(diff.Y, 2));
			}
			return difference / (testSet.Count - _predictor.HistorySize);
		}
	}
}
