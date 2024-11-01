
using RTATS.Core.Entities;

namespace RTATS.Core.ViewModel;
public sealed class AirlineTrafficSystemViewModel
    {

        public Pagination pagination { get; set; }
        public List<DataItem> data { get; set; }

}

