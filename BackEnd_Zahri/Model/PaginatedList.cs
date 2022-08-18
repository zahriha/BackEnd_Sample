using BackEnd.Zahri.Interface;

namespace BackEnd_Zahri.Model
{
    public class PaginatedList
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        private readonly IEnrollment _enrollment;

        public PaginatedList(IEnrollment enrollment, 
            int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            _enrollment = enrollment;
            
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}
