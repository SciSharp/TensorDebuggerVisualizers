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
			var len = sr.ReadByte();
			var dims = new long[len];
			var total = len == 0 ? 0 : 1;
			for (int i = 0; i < len; i++)
			{
				var dim = sr.ReadInt64();
				dims[i] = dim;
				total = (int)(total * dim);
			}
			var data = sr.ReadBytes(total);

			var dlg = new TensorViewer();
			dlg.Text = $"维度：{len}:{String.Join(",", dims)} 数据长度：{total}，实际收到{data.LongLength}。";

			windowService.ShowDialog(dlg);


		}
	}

}
