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
			byte ndim = 0;
			long[] dims = new long[0];
			byte[] data = new byte[0];
			int dataLength = 0;

			using var bw = new BinaryWriter(outgoingData);

			if (target is SharpCV.Mat mat)
			{
				dims = mat.shape.dims;
				ndim = (byte)dims.Length;
				data = mat.data.ToByteArray();
				dataLength = data.Length;
			}

			bw.Write(ndim);
			for (int i = 0; i < ndim; i++)
			{
				bw.Write(dims[i]);
			}
			bw.Write(dataLength);
			bw.Write(data);
		}

	}
}
