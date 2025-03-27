using System.Collections;

namespace Task1
{
    public class ServiceRequestDateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is ServiceRequest requestX && y is ServiceRequest requestY)
            {
                return requestX.CreatedDate.CompareTo(requestY.CreatedDate);
            }
            return 0;
        }
    }
}