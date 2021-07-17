using Microsoft.VisualStudio.DebuggerVisualizers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers
{
	public partial class MatDebuggerVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			using var stream = objectProvider.GetData();
			//using var sr = new System.IO.;
			//var bs = new byte[stream.Length];
			//var length = stream.Read(bs, 0, bs.Length);
			var bmp = new System.Drawing.Bitmap(stream);
			var dlg = new TensorViewer();
			dlg.BackgroundImage = bmp;
			windowService.ShowDialog(dlg);
		}
	}

}
