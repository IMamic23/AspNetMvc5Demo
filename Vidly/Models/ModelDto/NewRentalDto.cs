
using System.Collections.Generic;

namespace Vidly.Models.ModelDto
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}