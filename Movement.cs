using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSharp;
internal class Movement : Component {
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public (float X, float Y) Direction { get; set; } = (0, 0);

    public void SetDirection(float x, float y) {
        var length = MathF.Sqrt(x * x + y * y);
        Direction = length == 0 ? (0, 0) : (x / length, y / length);
    }
}
