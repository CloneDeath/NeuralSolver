using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NeuralSolver
{
	class Program
	{
		static void Main(string[] args){
			var testSets = new TestSet[]{
				new TestSet(@"data\training_data.txt"),
				new TestSet(@"data\test01.txt"),
				new TestSet(@"data\test02.txt"),
				new TestSet(@"data\test03.txt"),
				new TestSet(@"data\test04.txt"),
				new TestSet(@"data\test05.txt"),
				new TestSet(@"data\test06.txt"),
				new TestSet(@"data\test07.txt"),
				new TestSet(@"data\test08.txt"),
				new TestSet(@"data\test09.txt"),
				new TestSet(@"data\test10.txt"),
			};

			for (int historySize = 2; historySize < 2; historySize++){
				for (int hiddenSize = 2; hiddenSize < 2; hiddenSize++)
				{
					double avgDifference = 0;

					PositionPredictor predictor = new PositionPredictor(historySize, hiddenSize);

					Trainer trainer = new Trainer(predictor);

					foreach (var testSet in testSets){
						trainer.Train(testSet);
					}

					DifferenceTester tester = new DifferenceTester(predictor);
					foreach (var testSet in testSets){
						avgDifference += tester.GetDifference(testSet);
					}
					avgDifference /= testSets.Length;

					Console.WriteLine("History Size: {0}, Hidden Layer Size: {1}, Average Score: {2}", historySize, hiddenSize,
						avgDifference);
				}
			}
			Console.ReadLine();
		}
	}
}
