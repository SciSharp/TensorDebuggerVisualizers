using Microsoft.VisualStudio.DebuggerVisualizers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers
{
	public partial class TensorDebuggerVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			using var stream = objectProvider.GetData();
			using var sr = new System.IO.BinaryReader(stream);
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

			var dlg = new TensorViewer();
			dlg.Text = $"维度：{ndim}[{String.Join(",", dims)}] 秩，数据长度：{total} 字节，欲收 {dataLength} 字节，实收 {data.LongLength} 字节。";

			windowService.ShowDialog(dlg);


		}
	}

}
