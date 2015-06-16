using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralSolver
{
	class TestSet
	{
		List<Position> _positions = new List<Position>();

		public TestSet(string testfile){
			StreamReader reader = new StreamReader(File.OpenRead(testfile));
			while (!reader.EndOfStream){
				var line = reader.ReadLine();
				_positions.Add(StringToPosition(line));
			}
		}

		private Position StringToPosition(string line){
			var parts = line.Split(',');

			return new Position(){
				X = Int32.Parse(parts[0]),
				Y = Int32.Parse(parts[1])
			};
		}

		public Position GetPositionAtIndex(int index){
			return _positions[index];
		}

		public Position this[int i]{
			get { return _positions[i]; }
		}

		public int Count{
			get { return _positions.Count; }
		}
	}
}
