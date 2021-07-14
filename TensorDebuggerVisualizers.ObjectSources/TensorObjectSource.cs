using Microsoft.VisualStudio.DebuggerVisualizers;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers.ObjectSources
{
	public partial class TensorObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, Stream outgoingData)
		{
			byte size = 0;
			long[] dims = new long[0];
			byte[] data = new byte[0];

			using var bw = new BinaryWriter(outgoingData);

			if (target is SharpCV.Mat mat)
			{
				dims = mat.shape.dims;
				size = (byte)dims.Length;
				data = mat.data.ToByteArray();
			}

			bw.Write(size);
			for (int i = 0; i < size; i++)
			{
				bw.Write(dims[i]);
			}
			bw.Write(data);
		}

	}
}
