using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Infrastructure.Specifications;

public class BaseFilter
{
    public bool LoadChildren { get; set; }
    public bool IsPagingEnabled { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;

    public static BaseFilter Instance = new() { IsPagingEnabled = false };
}
