using DAL.Entities;
using DAL.Service;
using MongoDB.Bson;
using MongoEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoEx.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            var playerService = new PlayerService();
            return View(playerService.GetPlayers(100,0));
        }

        public ActionResult AddScore(string playerId, string gameId, string gameName)
        {
            var playerService = new PlayerService();
            var score = new Score
            {
                GameId = new ObjectId(gameId),
                GameName = gameName,
                ScoreDateTime = DateTime.Now,
                ScoreValue = new Random().Next(0, 100)
            };
            playerService.AddScore(playerId, score);
            return RedirectToAction("Details", new { id = playerId });
        }

        public ActionResult Create()
        {
            return View(new Player());
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playerService = new PlayerService();
                    playerService.Create(player);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public ActionResult Delete(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(Player player)
        {
            try
            {

                var playerService = new PlayerService();
                playerService.Delete(player.Id.ToString());
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }

            return View();
        }

        public ActionResult Details(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
            return View(player);
        }

        public ActionResult Edit(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playerService = new PlayerService();
                    playerService.Update(player);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

            } return View(player);
        }

        public ActionResult PlayGames(string id)
        {
            var playerService = new PlayerService();
            var gameService = new GameService();
            var player1 = playerService.GetById(id);
            var availableGames = gameService.List(100, 0).ToList();
            var playergames = new PlayerGames()
            {
                Player = player1,
                AvailableGames = availableGames
            };
            return View(playergames);
        }
    }
}