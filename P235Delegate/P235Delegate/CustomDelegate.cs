using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235Delegate
{
    delegate void Check();
    delegate void Check<in T1>();
    delegate void Check<in T1,in T2>();
    delegate void Check<in T1,in T2,in T3>();
}
