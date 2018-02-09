using System.Collections.Generic;

namespace ACME.Api.Controllers
{
    public class GameView
    {
        public int id { get; set; }
        public List<int> Frames { get; set; }
    }
}