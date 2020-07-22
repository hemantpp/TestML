using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestML
{
    class LabelCombCount
    {
        private string mLabelComb;
        private int mLabelCount;

        public LabelCombCount()
        {
            mLabelComb = "";
            mLabelCount = 0;
        }
          
        public string LabelComb
        {
            get { return mLabelComb; }
            set { mLabelComb = value; }
        }

        public int LabelCount
        {
            get { return mLabelCount; }
            set { mLabelCount = (int)value; }
        }

        
    }
}
