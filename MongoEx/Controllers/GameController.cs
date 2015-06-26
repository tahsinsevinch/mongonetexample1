using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Entities;
using DAL.Service;

namespace MongoEx.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            var gameService = new GameService();
            return View(gameService.List(100, 0));
        }
        public ActionResult Create()
        {
            return View(new Game() { 
                ReleaseDate=DateTime.Today,
                Played=false
            });
        }
        [HttpPost]
        public ActionResult Create(Game game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var gameservice = new GameService();
                    gameservice.Create(game);

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}