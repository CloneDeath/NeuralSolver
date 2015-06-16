using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralSolver
{
	class Trainer
	{
		private readonly PositionPredictor _subject;

		public Trainer(PositionPredictor subject){
			_subject = subject;
		}

		public void Train(TestSet trainingData){
			int history = _subject.HistorySize;

			for (int i = history - 1; i < trainingData.Count - 1; i++){
				List<Position> prevNodes = new List<Position>();

				for (int j = 0; j < history; j++){
					prevNodes.Add(trainingData[i - j]);
				}
				Position next = trainingData[i + 1];

				var prediction = _subject.GetPrediction(prevNodes.ToArray());
				//Console.WriteLine(prediction + " // " + (prediction - next));
				//Console.ReadLine();

				for (int j = 0; j < 1; j++){
					_subject.Train(next, prevNodes.ToArray());
				}
			}
		}
	}
}
