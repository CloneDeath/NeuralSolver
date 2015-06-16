using System.Collections.Generic;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;

namespace NeuralSolver{
	internal class PositionPredictor{
		private readonly int _samples;
		private readonly BackpropagationNetwork _network;

		public int HistorySize{
			get{
				return _samples;
			}
		}

		public PositionPredictor(int samples, int hiddenLayersize){
			_samples = samples;
			var inputLayer = new LinearLayer(samples * 2);

			var hiddenLayer = new LinearLayer(hiddenLayersize);
			var outputLayer = new LinearLayer(2);

			var c1 = new BackpropagationConnector(inputLayer, hiddenLayer);
			c1.Initializer = new NormalizedRandomFunction();
			c1.Initialize();

			var c2 = new BackpropagationConnector(hiddenLayer, outputLayer);
			c2.Initializer = new NormalizedRandomFunction();
			c2.Initialize();

			_network = new BackpropagationNetwork(inputLayer, outputLayer);
			_network.SetLearningRate(0.00000001);
		}

		public Position GetPrediction(params Position[] history){
			var result = _network.Run(GetInputs(history));
			return new Position{
				X = result[0],
				Y = result[1]
			};
		}

		private static double[] GetInputs(params Position[] history){
			List<double> ret = new List<double>();
			foreach (var pos in history){
				ret.Add(pos.X);
				ret.Add(pos.Y);
			}
			return ret.ToArray();
		}

		public void Train(Position next, params Position[] history){
			_network.Learn(new TrainingSample(GetInputs(history), new[]{next.X, next.Y}), 0, 1);
		}
	}
}