using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime;
using System.Web;
using System.Web.Mvc;
using WebApi.DAL;

namespace WebApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Error = (sender, args) =>
            {
                args.ErrorContext.Handled = true;
            },
        };
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //https://localhost:44301/home/GetClients
        [System.Web.Http.HttpGet]
        public string GetClients()
        {
            try
            {
                List<Client> lstClients = new List<Client>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    lstClients = db.Client.ToList();
                }
                return JsonConvert.SerializeObject(lstClients, settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //https://localhost:44301/home/GetShotsByTz
        [System.Web.Http.HttpGet]
        public string GetShotsByTz(string tz)
        {
            try
            {
                List<shot4Client> lstShots = new List<shot4Client>();
                using (var db = new HMO4Covid19_dbEntities())
                {

                    Shot s = new Shot();
                    lstShots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                    foreach (var shot in lstShots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                    {

                        lstShots = db.shot4Client.Where(x => x.codeShot == s.codeShot).ToList();
                        lstShots = db.shot4Client.ToList();
                    }

                }
                return JsonConvert.SerializeObject(lstShots, settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Http.HttpPost]
        //https://localhost:44301/home/AddClient
        public string AddClient(string tz, string firstName, string lastName, string postalCode, DateTime birthDate, string telephone, string selphone,
            DateTime beIllDate, DateTime beHealthDate, string city, string street, string numB)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Client client = db.Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
                    if (client != null)
                    {
                        //List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        //foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                        //{
                        //    db.shot4Client.Remove(shot);
                        //}
                        //db.Client.Remove(client);//מחיקת הלקוח מהרשימה

                        //db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "קיים פציינט כזה במאגר";
                    }
                    else
                    {
                        Client cl = new Client(tz, firstName, lastName, postalCode, birthDate, telephone, selphone, beIllDate, beHealthDate, city, street, numB);
                        db.Client.Add(cl);
                        db.SaveChanges();
                        return "נוסף בהצלחה";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Http.HttpPost]
        //https://localhost:44301/home/AddShot
        public string AddShot(string tz, DateTime shotDate)
        {
            try
            {
                List<shot4Client> lstShots = new List<shot4Client>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Client client = db.Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
                    if (client == null)
                    {
                        //List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        //foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                        //{
                        //    db.shot4Client.Remove(shot);
                        //}
                        //db.Client.Remove(client);//מחיקת הלקוח מהרשימה

                        //db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "לא קיים כזה פציינט";
                    }
                    else
                    {
                        lstShots = db.shot4Client.Where(x => x.tz == tz).ToList();
                        if (lstShots.Count() == 4)
                            return "הפציינט עשה כבר 4 חיסונים";
                        else
                        {
                            int codeShot = lstShots.Count() + 1;
                            shot4Client sh4cl = new shot4Client(tz, codeShot, shotDate);
                            db.shot4Client.Add(sh4cl);
                            db.SaveChanges();
                            return "נוסף בהצלחה";

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [System.Web.Http.HttpPut]
        //https://localhost:44301/home/UpdateClient
        public string UpdateClient(string tz, string firstName, string lastName, string postalCode, DateTime birthDate, string telephone, string selphone, DateTime beIllDate,
            DateTime beHealthDate, string city, string street, string numB)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Client cl = new Client(tz, firstName, lastName, postalCode, birthDate, telephone, selphone, beIllDate, beHealthDate, city, street, numB);
                    Client client = db.Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד 
                    if (client != null)
                    {
                        List<Client> cls = db.Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        Client oldCl=client;
                        db.Client.Add(cl);
                        db.Client.Remove(client);
                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "עודכן בהצלחה";
                    }
                    else return "לא קיים כזה פציינט";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [System.Web.Http.HttpPut]
        //https://localhost:44301/home/UpdateShot4Client
        public string UpdateShot4Client(string tz, int codeShot, DateTime shotDate)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    shot4Client cl = new shot4Client(tz, codeShot, shotDate);
                    shot4Client client = db.shot4Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד 
                    if (client != null)
                    {
                        List<shot4Client> cls = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        shot4Client oldCl = client;
                        if (cls.Count() == codeShot)
                        {
                            db.shot4Client.Add(cl);
                            db.shot4Client.Remove(client);
                            db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                            return "עודכן בהצלחה";
                        }
                        else if (cls.Count() != codeShot && cls.Count()<5)
                        {
                            int sh = cls.Count();
                            return " שים לב! הפציינט קיבל" + sh + " חיסונים ";
                        }
                    }
                     return "לא קיים כזה פציינט";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //https://localhost:44301/home/DeleteClient?tz 
        //sendfuc
        [System.Web.Http.HttpGet]
        public string DeleteClient(string tz)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Client client = db.Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
                    if (client != null)
                    {
                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                        {
                            db.shot4Client.Remove(shot);
                        }
                        db.Client.Remove(client);//מחיקת הלקוח מהרשימה

                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "True";
                    }
                    else return "False";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
