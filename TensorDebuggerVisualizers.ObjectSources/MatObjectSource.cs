using Microsoft.VisualStudio.DebuggerVisualizers;

using SharpCV;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TensorDebuggerVisualizers.ObjectSources
{
	public partial class MatObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, Stream outgoingData)
		{
			if (target is Mat mat)
			{
				var bs = mat.ImEncode();
				outgoingData.Write(bs, 0, bs.Length);
			}
		}
	}

}
