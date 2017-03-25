using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter.Instuments
{
    class ColorAndValue : IComparable
    {
        private int value;
        private Color color;
        public ColorAndValue(Color col)
        {
            color = col;
            value = col.R + col.G + col.B;
        }
        public int CompareTo(object obj)
        {
            ColorAndValue tmp = obj as ColorAndValue;
            if (value > tmp.value)
                return -1;
            if (value < tmp.value)
                return 1;
            return 0;
        }
        public Color GetColor()
        {
            return color;
        }
    }
}
