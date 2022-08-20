using BackEnd.Zahri.Interface;
using BackEnd_Zahri.DTO;

namespace BackEnd_Zahri.Model
{
    public class PaginatedList
    {
        public List<StudentReadDTO> Students { get; set; } = new List<StudentReadDTO>();
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }

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
