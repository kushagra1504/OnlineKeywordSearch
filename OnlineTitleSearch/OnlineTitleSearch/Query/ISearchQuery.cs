using OnlineTitleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Query
{
    public interface ISearchQuery
    { 
        string GetSearchPosition( SearchQueryModel query);
    }
}
