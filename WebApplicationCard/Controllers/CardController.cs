using Microsoft.AspNetCore.Mvc;
using WebApplicationCard.DAL;
using WebApplicationCard.Models;
using WebApplicationCard.Models.DBEntities;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplicationCard.Controllers
{
    public class CardController : Controller
    {
        private readonly CardDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CardController(CardDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Index(String SearchString)
        {
            if (SearchString != null)
            {
                var result = _context.Cards.Where(m => m.IdNum.ToString().Contains(SearchString)).ToList();
                List<CardViewModel> cardLists = new List<CardViewModel>();
                if (result != null)
                {

                    foreach (var card in result)
                    {
                        var CardViewModel = new CardViewModel()
                        {
                            IdCard = card.IdCard,
                            IdNum = card.IdNum,
                            FristName = card.FristName,
                            LastName = card.LastName,
                            Birthday = card.Birthday,
                            Religion = card.Religion,
                            Address = card.Address,
                            Outday = card.Outday,
                            EXPday = card.EXPday,
                            ImageUrl = card.ImageUrl
                        };
                        cardLists.Add(CardViewModel);
                    }
                    return View(cardLists);
                }
            }
            else
            {
                var result = _context.Cards.ToList();
                List<CardViewModel> cardList = new List<CardViewModel>();
                if (result != null)
                {

                    foreach (var card in result)
                    {
                        var CardViewModel = new CardViewModel()
                        {
                            IdCard = card.IdCard,
                            IdNum = card.IdNum,
                            FristName = card.FristName,
                            LastName = card.LastName,
                            Birthday = card.Birthday,
                            Religion = card.Religion,
                            Address = card.Address,
                            Outday = card.Outday,
                            EXPday = card.EXPday,
                            ImageUrl = card.ImageUrl
                        };
                        cardList.Add(CardViewModel);
                    }
                    return View(cardList);
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Create(long? IdCard, CardViewModel cardData)
        {
            string uniqueFileName = UploadedFile(cardData);
            cardData.ImageUrl = uniqueFileName;

            bool isEditState = (IdCard.HasValue && IdCard.Value > 0) ? true : false;
            ViewBag.IsEditState = isEditState;

            var card = _context.Cards.FirstOrDefault(x => x.IdCard == IdCard);
            if (IdCard.HasValue)
            {
                var cardView = new CardViewModel()
                {
                    IdCard = card.IdCard,
                    IdNum = card.IdNum,
                    FristName = card.FristName,
                    LastName = card.LastName,
                    Birthday = card.Birthday,
                    Religion = card.Religion,
                    Address = card.Address,
                    Outday = card.Outday,
                    EXPday = card.EXPday,
                    ImageUrl = card.ImageUrl
                };
                return View(cardView);
            }
            else
            {
                return View(new CardViewModel());
            }
        }

        [HttpPost]
        public IActionResult Create(CardViewModel cardData)
        {

            if (cardData.IdCard == 0 )
            {
                string uniqueFileName = UploadedFile(cardData);
                cardData.ImageUrl = uniqueFileName;
                var card = new Card()
                {
                    IdCard = cardData.IdCard,
                    IdNum = cardData.IdNum,
                    FristName = cardData.FristName,
                    LastName = cardData.LastName,
                    Birthday = cardData.Birthday,
                    Religion = cardData.Religion,
                    Address = cardData.Address,
                    Outday = cardData.Outday,
                    EXPday = cardData.EXPday,
                    ImageUrl = cardData.ImageUrl
                };
                _context.Cards.Add(card);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if(cardData.Picture != null)
                {
                    string uniqueFileName = UploadedFile(cardData);
                    cardData.ImageUrl = uniqueFileName;
                }
                var card = new Card()
                {
                    IdCard = cardData.IdCard,
                    IdNum = cardData.IdNum,
                    FristName = cardData.FristName,
                    LastName = cardData.LastName,
                    Birthday = cardData.Birthday,
                    Religion = cardData.Religion,
                    Address = cardData.Address,
                    Outday = cardData.Outday,
                    EXPday = cardData.EXPday,
                    ImageUrl = cardData.ImageUrl
                };
                _context.Cards.Update(card);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        public IActionResult Delete(long? IdCard)
        {
           
            var card = _context.Cards.FirstOrDefault(x => x.IdCard == IdCard);
            if (card != null)
            {
                var cardView = new CardViewModel()
                {
                    IdCard = card.IdCard,
                    IdNum = card.IdNum,
                    FristName = card.FristName,
                    LastName = card.LastName,
                    Birthday = card.Birthday,
                    Religion = card.Religion,
                    Address = card.Address,
                    Outday = card.Outday,
                    EXPday = card.EXPday,
                    ImageUrl = card.ImageUrl
                };
                _context.Cards.Remove(card);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        private string UploadedFile(CardViewModel file)
        {
            string uniqueFileName = null;
            if (file.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.Picture.CopyTo(fileStream);
                }


            }
            return uniqueFileName;

        }

    }
}
