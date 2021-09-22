using Microsoft.VisualStudio.DebuggerVisualizers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers
{
	using static TensorStreamHelper;
	public partial class TensorDebuggerVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			using var stream = objectProvider.GetData();

			var (dims, data) = stream.ReadTensor();
			var ndim = (byte)dims.Length;
			long total = (ndim == 0 ? 0 : 1);
			for (int i = 0; i < ndim; i++)
			{
				var dim = dims[i];
				total *= dim;
			}

			var dataLength = data.Length;

			var dlg = new TensorViewer();
			dlg.Text = $"维度：{ndim}[{String.Join(",", dims)}] 秩，数据长度：{total} 字节，应收 {dataLength} 字节，实收 {data.LongLength} 字节。";

			windowService.ShowDialog(dlg);

		}
	}

}
