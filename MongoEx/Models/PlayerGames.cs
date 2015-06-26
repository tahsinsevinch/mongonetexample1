using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Entities;

namespace MongoEx.Models
{
    public class PlayerGames
    {
        public Player Player { get; set; }
        public List<Game> AvailableGames { get; set; }
    }
}