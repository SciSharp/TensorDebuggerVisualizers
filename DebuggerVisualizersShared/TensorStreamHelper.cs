using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TensorDebuggerVisualizers
{
	public static class TensorStreamHelper
	{
#if NETCOREAPP
		public static long WriteTensor(this Stream outgoingData, SharpCV.Mat mat)
		{
			var dims = mat.shape.dims;
			var data = mat.data.ToByteArray();
			return WriteTensor(outgoingData, dims, data);
		}

		public static long WriteTensor(this Stream outgoingData, Tensorflow.Tensor tensor)
		{
			var dims = tensor.dims;
			var data = tensor.BufferToArray();
			return WriteTensor(outgoingData, dims, data);
		}

#endif
		public static long WriteTensor(this Stream outgoingData, long[] dims, byte[] data)
		{
			var ndim = (byte)dims.Length;
			var dataLength = data.Length;

			using var bw = new BinaryWriter(outgoingData);
			bw.Write(ndim);
			for (int i = 0; i < ndim; i++)
			{
				bw.Write(dims[i]);
			}
			bw.Write(dataLength);
			bw.Write(data);

			bw.Flush();

			return dataLength;
		}

		public static (long[] dims, byte[] data) ReadTensor(this Stream comingData)
		{
			using var sr = new System.IO.BinaryReader(comingData);
			var ndim = sr.ReadByte();
			var dims = new long[ndim];
			long total = (ndim == 0 ? 0 : 1);
			for (int i = 0; i < ndim; i++)
			{
				var dim = sr.ReadInt64();
				dims[i] = dim;
				total = total * dim;
			}

			var dataLength = sr.ReadInt32();

			var data = sr.ReadBytes(dataLength);

			return (dims, data);
		}

	}
}
