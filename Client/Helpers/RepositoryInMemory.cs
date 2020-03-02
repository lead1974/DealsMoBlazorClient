using DealsMo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealsMo.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Deal> GetDeals()
        {
            return new List<Deal>()
    {
                new Deal(){Title = "Spider-Man: Far From Home",
                    ReleaseDate = new DateTime(2019, 7, 2),
                    ImageURL = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg"
                },
                new Deal(){Title = "Moana", 
                    ReleaseDate = new DateTime(2016, 11, 23),
                    ImageURL = "https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_SY1000_CR0,0,674,1000_AL_.jpg"
                },
                new Deal(){Title = "Inception", 
                    ReleaseDate = new DateTime(2010, 7, 16),
                    ImageURL = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"
                }
            };
        }
    }
}
