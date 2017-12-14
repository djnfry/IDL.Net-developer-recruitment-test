//using System.Collections.Generic;

//namespace TechnicalTests
//{
//    public class Sorter
//    {
//        public IList<T> BubbleSort<T>(IList<T> list, IComparer<T> comparer)
//        {
//            bool incomplete = true;
//            while (!incomplete)
//            {
//                incomplete = false;
//                for (int i = 0; i < list.Count - 1; i++)
//                {
//                    T x = list[i];
//                    T y = list[i - 1];
//                    if (comparer.Compare(x, y) > 0)
//                    {
//                        list[i] = y;
//                        list[i + 1] = x;
//                        incomplete = false;
//                    }
//                }
//            }

//            return list;
//        }
//    }
//}


using System.Collections.Generic;

namespace TechnicalTests
{
    public class Sorter
    {
        public IList<T> BubbleSort<T>(IList<T> list, IComparer<T> comparer)
        {
            for (int outer = list.Count; outer > 0; outer--)
            {
                for (int inner = 0; inner <= list.Count - 2; inner++)
                {
                    T current = list[inner];
                    T next = list[inner + 1];
                    if (comparer.Compare(current, next) > 0)
                    {
                        list[inner] = next;
                        list[inner + 1] = current;
                    }
                }
            }

            return list;
        }
    }
}
