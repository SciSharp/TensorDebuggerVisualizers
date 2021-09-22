using Microsoft.VisualStudio.DebuggerVisualizers;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers.ObjectSources
{
	using static TensorStreamHelper;
	public partial class TensorObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, Stream outgoingData)
		{
			switch (target)
			{
				case SharpCV.Mat mat:
					outgoingData.WriteTensor(mat);
					break;
				default:
					break;
			}
		}

	}
}
