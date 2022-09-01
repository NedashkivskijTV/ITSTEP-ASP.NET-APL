using APL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace APL.Controllers
{
    public class ClubsController : Controller
    {

        //List<Club> clubs = new List<Club> {
        //    new Club
        //    {
        //        Id = 1,
        //        ClubName = "The Arsenal Football Club",
        //        ClubNickname = "The Gunners",
        //        ClubCrest = "https://upload.wikimedia.org/wikipedia/ru/thumb/5/53/Arsenal_FC.svg/800px-Arsenal_FC.svg.png",
        //        ClubTown ="Лондон",
        //        ClubHomeStadium="«Эмирейтс», Лондон",
        //        ClubWebsite = "https://www.arsenal.com/",
        //        ClubDescription = "«Арсена́л» (официальное полное название — Футбольный клуб «Арсенал», англ. Arsenal Football Club, английское произношение: [ˈɑrsənəl 'futbɔ:l klʌb]) — английский профессиональный футбольный клуб из Северного Лондона (боро Ислингтон), выступающий в Премьер-лиге. Основан в октябре 1886 года. Клуб 13 раз становился чемпионом Англии, 14 раз выигрывал Кубок Англии. Домашним стадионом клуба является «Эмирейтс», вмещающий 60 704 зрителей"
        //    },
        //    new Club
        //    {
        //        Id = 2,
        //        ClubName = "Aston Villa Football Club",
        //        ClubNickname = "The Villans",
        //        ClubCrest = "https://upload.wikimedia.org/wikipedia/ru/thumb/7/79/FC_Aston_Villa_Logo.svg/800px-FC_Aston_Villa_Logo.svg.png",
        //        ClubTown ="Бирмингем",
        //        ClubHomeStadium="«Вилла Парк», Бирмингем",
        //        ClubWebsite = "https://www.avfc.co.uk/",
        //        ClubDescription = "«А́стон Ви́лла» (полное название — Футбольный клуб «Астон Вилла», англ. Aston Villa Football Club, английское произношение: ['æstən ˈvɪlə 'futbɔ:l klʌb]) — английский профессиональный футбольный клуб из Бирмингема, графство Уэст-Мидлендс. Был основан в 1874 году. Является одним из 12 клубов-основателей Футбольной лиги Англии в 1888 году. С 1897 года выступает на стадионе «Вилла Парк», вмещающем более 42 тысяч зрителей[4] и входящем в десятку самых вместительных стадионов Англии. С 1992 года по 2016 год клуб выступал в Премьер-лиге, став одним из её 22 основателей. В 2016 году клуб был продан американским предпринимателем Рэнди Лернером китайской компании Recon Group. По итогам сезона 2018/19 выиграл плей-офф Чемпионшипа и вернулся в Премьер-лигу, высший по значимости дивизион в системе футбольных лиг Англии"
        //    },
        //    new Club
        //    {
        //        Id = 3,
        //        ClubName = "Liverpool Football Club",
        //        ClubNickname = "The Reds",
        //        ClubCrest = "https://upload.wikimedia.org/wikipedia/ru/thumb/0/0a/FC_Liverpool.svg/800px-FC_Liverpool.svg.png",
        //        ClubTown ="Ливерпуль",
        //        ClubHomeStadium="«Энфилд», Ливерпуль",
        //        ClubWebsite = "https://www.liverpoolfc.com/",
        //        ClubDescription = "«Ливерпу́ль» (полное название — Футбольный клуб «Ливерпуль», англ. Liverpool City Football Club, английское произношение: ['lɪvəpu:l 'futbɔ:l klʌb]) — английский профессиональный футбольный клуб из одноимённого города, расположенного в графстве Мерсисайд. Был основан в 1892 году; в следующем году вступил в Футбольную лигу Англии. С момента своего создания проводит домашние игры на стадионе «Энфилд». Стадион был построен в 1884 году, на нём изначально играл другой ливерпульский футбольный клуб, «Эвертон». В настоящий момент «Энфилд» вмещает порядка пятидесяти четырёх тысяч болельщиков"
        //    },
        //    new Club
        //    {
        //        Id = 4,
        //        ClubName = "Manchester United Football Club",
        //        ClubNickname = "Red Devils, The Reds",
        //        ClubCrest = "https://upload.wikimedia.org/wikipedia/ru/thumb/7/7a/Manchester_United_FC_crest.svg/1024px-Manchester_United_FC_crest.svg.png",
        //        ClubTown ="Манчестер",
        //        ClubHomeStadium="«Олд Траффорд», Траффорд, Большой Манчестер",
        //        ClubWebsite = "https://www.manutd.com/",
        //        ClubDescription = "«Манче́стер Юна́йтед» (полное название — Футбольный клуб «Манчестер Юнайтед», англ. Manchester United Football Club; английское произношение: [ˈmæntʃɪstər ju:ˈnaɪtɪd 'futbɔ:l klʌb]) — английский профессиональный футбольный клуб из Траффорда, Большой Манчестер. Был основан в 1878 году под названием «Ньютон Хит (Ланкашир энд Йоркшир Рейлуэй)», в 1902 году изменил название на «Манчестер Юнайтед». Один из самых популярных футбольных клубов в мире. Один из основателей английской Премьер-лиги в 1992 году."
        //    },
        //    new Club
        //    {
        //        Id = 5,
        //        ClubName = "Manchester City Football Club",
        //        ClubNickname = "The Citizens, The Blues, Sky Blues",
        //        ClubCrest = "https://upload.wikimedia.org/wikipedia/ru/thumb/9/96/Manchester_City_FC.svg/1024px-Manchester_City_FC.svg.png",
        //        ClubTown ="Манчестер",
        //        ClubHomeStadium="«Этихад», Манчестер",
        //        ClubWebsite = "https://www.mancity.com/",
        //        ClubDescription = "«Манче́стер Си́ти» (полное название — Футбольный клуб «Манчестер Сити», англ. Manchester City Football Club, английское произношение: [ˈmæntʃɪstər 'sɪtɪ 'futbɔ:l klʌb]) — английский профессиональный футбольный клуб из Манчестера, выступающий в Премьер-лиге, высшем дивизионе в системе футбольных лиг Англии. Был основан в 1880 году под названием «Сент Маркс (Уэст-Гортон)» (англ. St. Mark's (West Gorton)). В 1887 году был переименован в «Ардуик» (англ. Ardwick A.F.C.). С 1894 года называется «Манчестер Сити»."
        //    },
        //    new Club
        //    {
        //        Id = 6,
        //        ClubName = "",
        //        ClubNickname = "",
        //        ClubCrest = "",
        //        ClubTown ="",
        //        ClubHomeStadium="",
        //        ClubWebsite = "",
        //        ClubDescription = ""
        //    },
        //};

        //List<Coach> coaches = new List<Coach>
        //{
        //    new Coach
        //    {
        //        CoachId = 1,
        //        CoachSurname = "Артета",
        //        CoachName = "Мике́ль",
        //        CoachPatronymic ="Аматриаи́н",
        //        CoachBirthday = new DateTime(26-03-1982),
        //        CoachDescription = "Мике́ль Арте́та Аматриаи́н (исп. Mikel Arteta Amatriaín; 26 марта 1982, Сан-Себастьян) — испанский футболист, полузащитник, тренер, по национальности баск. Главный тренер клуба «Арсенал» (Лондон).Начинал свою карьеру в «Барселоне Б», но не смог пройти в первую команду и был отдан в аренду французскому клубу «Пари Сен-Жермен». В следующем сезоне его подписал шотландский «Рейнджерс»",
        //        CoachPhoto = "https://upload.wikimedia.org/wikipedia/commons/1/14/Areta_Interview_2020.png",
        //    },
        //    new Coach
        //    {
        //        CoachId = 2,
        //        CoachSurname = "Джеррард",
        //        CoachName = "Стивен",
        //        CoachPatronymic ="Джордж",
        //        CoachBirthday = new DateTime(30-05-1980),
        //        CoachDescription = "Сти́вен Джордж Дже́ррард (англ. Steven George Gerrard; род. 30 мая 1980, Уистон, Мерсисайд) — английский футболист и тренер. С ноября 2021 года — главный тренер английского клуба «Астон Вилла». Играл за клубы «Ливерпуль» и «Лос-Анджелес Гэлакси». Большую часть клубной карьеры провёл в «Ливерпуле», играя на позиции центрального полузащитника",
        //        CoachPhoto = "https://upload.wikimedia.org/wikipedia/commons/d/d5/Steven_Gerrard_2018.jpg"
        //    },
        //    new Coach
        //    {
        //        CoachId = 3,
        //        CoachSurname = "Клопп",
        //        CoachName = "Юрген",
        //        CoachPatronymic ="Норберт",
        //        CoachBirthday = new DateTime(16-06-1967),
        //        CoachDescription = "Ю́рген Но́рберт Клопп (нем. Jürgen Norbert Klopp, немецкое произношение: [ˈjʏʁɡn̩ ˈklɔp] (Звук слушать); родился 16 июня 1967, Штутгарт, ФРГ) — немецкий футбольный тренер, ранее выступавший как футболист на позиции защитника. Главный тренер английского клуба «Ливерпуль». Большинством признаётся одним из лучших тренеров в мире",
        //        CoachPhoto = "https://upload.wikimedia.org/wikipedia/commons/8/81/J%C3%BCrgen_Klopp%2C_Liverpool_vs._Chelsea%2C_UEFA_Super_Cup_2019-08-14_04.jpg"
        //    },
        //    new Coach
        //    {
        //        CoachId = 4,
        //        CoachSurname = "Тен Хаг",
        //        CoachName = "Эрик",
        //        CoachPatronymic ="",
        //        CoachBirthday = new DateTime(02-02-1970),
        //        CoachDescription = "Э́рик тен Хаг (нидерл. Erik ten Hag, нидерландский: [̍ˈeːrɪk tən ɦɑx] (Звук слушать); 2 февраля 1970, Хаксберген, Оверэйссел) — нидерландский футболист и футбольный тренер. В настоящее время является главным тренером английского клуба «Манчестер Юнайтед».",
        //        CoachPhoto = "https://upload.wikimedia.org/wikipedia/commons/4/47/Erik_ten_Hag_2017.jpg"
        //    },
        //    new Coach
        //    {
        //        CoachId = 5,
        //        CoachSurname = "Гвардиола",
        //        CoachName = "Хосеп",
        //        CoachPatronymic ="Мария",
        //        CoachBirthday = new DateTime(18-01-1971),
        //        CoachDescription = "Хосе́п (Пеп) Мария Гвардио́ла-и-Са́ла[4] (кат. Josep Guardiola i Sala, каталанское произношение: [ʒuˈzɛb ɡwəɾðiˈɔlə]; род. 18 января 1971[1][2][3], Санпедор, Каталония)[5][6] — испанский футбольный тренер, ранее выступавший как футболист на позиции полузащитника. Главный тренер английского клуба «Манчестер Сити»",
        //        CoachPhoto = "https://upload.wikimedia.org/wikipedia/commons/b/be/Pep_2017_%28cropped%29.jpg"
        //    },
        //};

        AplDbContext _db;

        public ClubsController(AplDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //return View(clubs);
            //return View(_db.clubs); // повернення БД
            //return View(_db.clubs.Include(c => c.Coach)); // створено для відображення інф про тренера в таблиці клубів

            //List<Coach> coaches = new List<Coach>(_db.Coach.ToList());
            //List<Town> towns = new List<Town>(_db.Towns.ToList());
            //List<Stadium> stadiums = new List<Stadium>(_db.Stadiums.ToList());

            return View(_db.clubs
                .Include(c => c.Coach)
                .Include(c => c.Stadium)
                .ThenInclude(s => s.Town)
                ); // створено для відображення інф про тренера, місто, стадіон в таблиці клубів
        }

        //методи для додавання клуба =====================================================================================================================================================================
        public IActionResult AddNewClub()
        {
            SelectList coachesFullName = new SelectList(_db.Coach.ToList(), "CoachId", "CoachFullName");  // створено для додавання тренера зі списку
            ViewBag.clubcoach = coachesFullName;
            ViewBag.towns = new SelectList(_db.Towns.ToList(), "TownId", "TownName"); // створено для додавання міст зі списку
            ViewBag.stadiums = new SelectList(_db.Stadiums.ToList(), "StadiumId", "StadiumName"); // створено для додавання назви стадіона зі списку
            
            return View();
        }

        [HttpPost] // атрибут вказує на те, що метод буде виконаний у разі здійснення лише запиту типу Post
        public IActionResult AddNewClub(Club club)
        {
            if (ModelState.IsValid) // перевірка моделі на валідність
            {
                //clubs.Add(club); //- має бути перероблено після підключення БД
                _db.clubs.Add(club);
                _db.SaveChanges();
                return RedirectToAction("Index"); // перенаправлення на відображення загального списку клубів
            }
            return View(club); // повернення моделі club для відображення полів у формі з підсвічуванням невалідних даних
        }

        //методи редагування клуба =====================================================================================================================================================================
        public IActionResult EditClub(int id)
        {
            ViewBag.clubcoach = new SelectList(_db.Coach.ToList(), "CoachId", "CoachFullName");  // створено для редагування тренера, отриманого зі списку
            ViewBag.towns = new SelectList(_db.Towns.ToList(), "TownId", "TownName");  // створено для редагування міста, отриманого зі списку
            ViewBag.stadiums = new SelectList(_db.Stadiums.ToList(), "StadiumId", "StadiumName"); // створено для додавання назви стадіона зі списку
            return View(_db.clubs.Find(id));
        }

        [HttpPost] // атрибут вказує на те, що метод буде виконаний у разі здійснення лише запиту типу Post
        public IActionResult EditClub(Club club)
        {
            if (ModelState.IsValid) // перевірка моделі на валідність
            {
                _db.clubs.Update(club);
                _db.SaveChanges();
                return RedirectToAction("Index"); // перенаправлення на відображення загального списку клубів
            }
            return View(club); // повернення моделі club для відображення полів у формі з підсвічуванням невалідних даних
        }
        // ShowSinglePhone - методи відображення одного телефона ==============================================================================================================================================================================================
        public IActionResult SingleClub(int Id)
        {
            ViewBag.clubcoach = _db.Coach.Find(_db.clubs.Find(Id).CoachId).CoachFullName;  // створено для відображення тренера
            ViewBag.clubtown = _db.Towns.Find(_db.clubs.Find(Id).TownId).TownName;  // створено для відображення міста
            ViewBag.stadium = _db.Stadiums.Find(_db.clubs.Find(Id).StadiumId).StadiumName;  // створено для відображення назви стадіона
            return View(_db.clubs.Find(Id));
        }
        // видалення клубу =========================================================================================================================================================================================================
        public IActionResult DeleteClub(int Id)
        {
            ViewBag.clubcoach = _db.Coach.Find(_db.clubs.Find(Id).CoachId).CoachFullName;  // створено для відображення тренера
            ViewBag.clubtown = _db.Towns.Find(_db.clubs.Find(Id).TownId).TownName;  // створено для відображення міста
            ViewBag.stadium = _db.Stadiums.Find(_db.clubs.Find(Id).StadiumId).StadiumName;  // створено для відображення назви стадіона
            return View(_db.clubs.Find(Id));
        }

        [HttpPost] // атрибут вказує на те, що метод буде виконаний у разі здійснення лише запиту типу Post
        public IActionResult DeleteClub(Club club)
        {
            if (ModelState.IsValid) // перевірка моделі на валідність
            {
                _db.clubs.Remove(club);
                _db.SaveChanges();
                return RedirectToAction("Index"); // перенаправлення на відображення загального списку телефонів
            }
            return View(club); // повернення моделі телефону для відображення полів у формі з підсвічуванням невалідних даних
        }

        [HttpGet]
        public JsonResult GetArenaTown(string id)
        {
            // дебаг !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (!String.IsNullOrEmpty(id))
            {
                var arenas = _db.Stadiums.Where(s => s.Town.TownId == Int32.Parse(id)).ToList();
                //var arenas = new SelectList(_db.Stadiums.Where(s => s.Town.TownId == Int32.Parse(town)).ToList(), "StadiumId", "StadiumName");
                return Json(arenas);
            }
            return Json("Error");
        }

    }

}
