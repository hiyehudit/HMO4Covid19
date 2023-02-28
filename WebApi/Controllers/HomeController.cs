//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;
//using WebApi.DAL;
//using WebApi.DTO;


//namespace WebApi.Controllers
//{
//    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
//    public class HomeController : ApiController
//    {
//        private HMO4Covid19_dbEntities db = new HMO4Covid19_dbEntities();
//        Clients Controller
//         GET: api/Default3
//        [HttpGet]
//        [Route("api/Default3/getClient")]
//        public PersonDTO getClient(string tz)
//        {
//            Person p = db.Person.Find(tz);

//            if (p == null)
//            {
//                return null;
//            }
//            PersonDTO personDTO = new PersonDTO(p);


//            return personDTO;

//        }
//        [HttpGet]
//        [Route("api/Default3/getClients")]
//        public List<PersonDTO> getClients()
//        {
//            try
//            {
//                List<Person> lstClients = new List<Person>();
//                List<PersonDTO> lstClientsDTO = new List<PersonDTO>();
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    lstClients = db.Person.ToList();
//                }
//                foreach (var item in lstClients)
//                {
//                    lstClientsDTO.Add(new PersonDTO(item));
//                }
//                return lstClientsDTO;
//            }
//            catch (Exception ex)
//            {
//                return null;

//            }

//        }
//        [HttpPost]
//        [Route("api/Default3/AddClient")]
//        public string AddClient(PersonDTO c)
//        {
//            Person cl = new Person(c.tz, c.firstName, c.lastName, c.postalCode, c.birthDate ?? new DateTime(), c.telephone, c.selphone, c.beIllDate ?? new DateTime(), c.beHealthDate ?? new DateTime());
//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    Person client = db.Person.FirstOrDefault(x => x.tz == c.tz);//שליםת הלקוח המיועד למחיקה

//                    if (client != null)
//                    {
//                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                        {
//                            db.shot4Client.Remove(shot);
//                        }
//                        db.Client.Remove(client);//מחיקת הלקוח מהרשימה

//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return "קיים פציינט כזה במאגר";
//                    }
//                    else
//                    {
//                        db.Person.Add(cl);
//                        db.SaveChanges();
//                        return "נוסף בהצלחה";
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//                throw ex;
//            }
//        }
//        [HttpPost]
//        [Route("api/Default3/UpdateClient")]
//        public string UpdateClient([FromBody] PersonDTO c)
//        {
//            try
//            {
//                Person cl = new Person(c.tz, c.firstName, c.lastName, c.postalCode, c.birthDate ?? new DateTime(), c.telephone, c.selphone, c.beIllDate ?? new DateTime(), c.beHealthDate ?? new DateTime());

//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    Person client = db.Person.FirstOrDefault(x => x.tz == c.tz);//שליםת הלקוח המיועד 
//                    if (client != null)
//                    {
//                        List<Person> cls = db.Person.Where(x => x.tz == c.tz).ToList();//שליפת כל החיסונים של הלקוח
//                        Person oldCl = client;
//                        db.Person.Add(cl);
//                        db.Person.Remove(client);
//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return "עודכן בהצלחה";
//                    }
//                    else
//                        return "לא קיים כזה פציינט";
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }
//        [HttpGet]
//        [Route("api/Default3/DeleteClient")]
//        public bool DeleteClient(string tz)
//        {
//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    Person client = db.Person.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
//                    if (client != null)
//                    {
//                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                        {
//                            db.shot4Client.Remove(shot);
//                        }
//                        db.Person.Remove(client);//מחיקת הלקוח מהרשימה

//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return true;
//                    }
//                    else return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//         /// <summary>
//        / T_Adress controllers
//        / </summary>
//        / <returns></returns>
//        [HttpGet]
//        [Route("api/Default3/getAdress")]
//        public AdressDTO getAdress(string tz)
//        {

//            T_Address a = db.T_Address.Find(tz);


//            if (a == null)
//            {
//                return null;
//            }
//            AdressDTO adressDTO = new AdressDTO(a);


//            return adressDTO;

//        }
//        [HttpPost]
//        [Route("api/Default3/AddAdress")]
//        public string AddAdress(AdressDTO aDTO)
//        {
//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    T_Address a = db.T_Address.FirstOrDefault(x => x.tz == aDTO.tz);//שליםת הלקוח המיועד למחיקה
//                    if (a != null)
//                    {
//                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                        {
//                            db.shot4Client.Remove(shot);
//                        }
//                        db.Client.Remove(client);//מחיקת הלקוח מהרשימה

//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return "יש לך כתובת";
//                    }
//                    else
//                    {
//                        T_Address cl = new T_Address(aDTO.tz, aDTO.postalCode, aDTO.numBuild, aDTO.city, aDTO.street);
//                        db.T_Address.Add(cl);
//                        db.SaveChanges();
//                        return "נוסף בהצלחה";
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//                throw ex;
//            }
//        }
//        [HttpPost]
//        [Route("api/Default3/UpdateAdress")]
//        public string UpdateAdress([FromBody] AdressDTO aDTO)
//        {
//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    T_Address cl = new T_Address(aDTO.tz, aDTO.postalCode, aDTO.numBuild, aDTO.city, aDTO.street);
//                    T_Address client = db.T_Address.FirstOrDefault(x => x.tz == aDTO.tz);//שליםת הלקוח המיועד 
//                    if (client != null)
//                    {
//                        < T_Address > cls = db.T_Address.Where(x => x.tz == aDTO.tz).ToList();
//                        T_Address oldCl = client;
//                        db.T_Address.Add(cl);
//                        db.T_Address.Remove(client);
//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return "עודכן בהצלחה";
//                    }
//                    else return "לא קיים כזה פציינט";
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }

//        / <summary>
//        / shot
//        / </summary>
//        / <returns></returns>

//        [HttpGet]
//        [Route("api/Default3/GetManufactorersByTz")]
//        public string GetManufactorersByTz(int codeShot)
//        {
//            Shot a = db.Shot.Find(codeShot);

//            if (a == null)
//            {
//                return null;
//            }
//            return a.manufactorer;

//        }
//        [HttpGet]
//        [Route("api/Default3/getShots")]
//        public List<ShotDTO> getShots()
//        {
//            try
//            {
//                List<Shot> lstShot = new List<Shot>();
//                List<ShotDTO> lstShotDTO = new List<ShotDTO>();
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    lstShot = db.Shot.ToList();
//                }
//                foreach (var item in lstShot)
//                {
//                    lstShotDTO.Add(new ShotDTO(item));
//                }
//                return lstShotDTO;
//            }
//            catch (Exception ex)
//            {
//                return null;

//            }

//        }

//        / <summary>
//        / shot4
//        / </summary>
//        / <returns></returns>
//        / 
//        [HttpGet]
//        [Route("api/Default3/GetShots4ByTz")]
//        public List<shot4ClientDTO> GetShots4ByTz(string tz)
//        {
//            try
//            {
//                List<shot4Client> lstShots = new List<shot4Client>();
//                List<shot4ClientDTO> lstShotsDTO = new List<shot4ClientDTO>();

//                using (var db = new HMO4Covid19_dbEntities())
//                {

//                    lstShots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                    foreach (var shot in lstShots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                    {
//                        lstShotsDTO.Add(new shot4ClientDTO(shot));
//                    }

//                }
//                return htt
//                return lstShotsDTO;
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }
//        [HttpPost]
//        [Route("api/Default3/AddShot4")]
//        public string AddShot4(shot4ClientDTO s)
//        {
//            shot4Client gg = new shot4Client(s);
//            try
//            {
//                List<shot4Client> lstShots = new List<shot4Client>();
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    Person client = db.Person.FirstOrDefault(x => x.tz == gg.tz);
//                    if (client == null)
//                    {
//                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                        {
//                            db.shot4Client.Remove(shot);
//                        }
//                        db.Client.Remove(client);//מחיקת הלקוח מהרשימה

//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return "לא קיים כזה פציינט";
//                    }
//                    else
//                    {
//                        lstShots = db.shot4Client.Where(x => x.tz == gg.tz).ToList();
//                        if (lstShots.Count() == 4)
//                            return "הפציינט עשה כבר 4 חיסונים";
//                        else
//                        {
//                            int codeShot = lstShots.Count() + 1;
//                            shot4Client sh4cl = new shot4Client(gg.tz, gg.codeShot, gg.shotDate, gg.Id_shot4Client);
//                            db.shot4Client.Add(gg);
//                            db.SaveChanges();
//                            return "נוסף בהצלחה";

//                        }


//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();

//            }
//        }
//        [HttpPost]
//        [Route("api/Default3/UpdateShot4Client")]
//        public string UpdateShot4Client(shot4ClientDTO s)
//        {
//            shot4Client gg = new shot4Client(s);

//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    shot4Client cl = new shot4Client(tz, codeShot, shotDate);

//                    shot4Client client = db.shot4Client.FirstOrDefault(x => x.tz == gg.tz);
//                    if (client != null)
//                    {
//                        List<shot4Client> cls = db.shot4Client.Where(x => x.tz == gg.tz).ToList();//שליפת כל החיסונים של הלקוח
//                        shot4Client oldCl = client;
//                        if (cls.Count() == gg.codeShot)
//                        {
//                            db.shot4Client.Add(gg);
//                            db.shot4Client.Remove(client);
//                            db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                            return "עודכן בהצלחה";
//                        }
//                        else if (cls.Count() != gg.codeShot && cls.Count() < 5)
//                        {
//                            int sh = cls.Count();
//                            return " שים לב! הפציינט קיבל" + sh + " חיסונים ";
//                        }
//                    }
//                    return "לא קיים כזה פציינט";
//                }
//            }
//            catch (Exception ex)
//            {
//                return ex.ToString();
//            }
//        }
//        [HttpGet]
//        [Route("api/Default3/DeleteShot4")]
//        {
//            try
//            {
//                using (var db = new HMO4Covid19_dbEntities())
//                {
//                    shot4Client shot4 = db.shot4Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
//                    if (shot4 != null)
//                    {
//                        db.shot4Client.Remove(shot4);
//                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                        return true;
//                    }
//                    else return false;
//                }
//            }
//            catch (Exception ex)
//{
//    throw ex;
//}
//        }
//        [HttpPost] [Route("api/Default3/VerifyUser")]

//[Route("api/Default3/AddShot4")]
//public string AddShot4(shot4ClientDTO s)
//{
//    shot4Client gg = new shot4Client(s);
//    try
//    {
//        List<shot4Client> lstShots = new List<shot4Client>();
//        using (var db = new HMO4Covid19_dbEntities())
//        {
//            Person client = db.Person.FirstOrDefault(x => x.tz == gg.tz);
//            if (client == null)
//            {
//                List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
//                foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
//                {
//                    db.shot4Client.Remove(shot);
//                }
//                db.Client.Remove(client);//מחיקת הלקוח מהרשימה

//                db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
//                return "לא קיים כזה פציינט";
//            }
//            else
//            {
//                lstShots = db.shot4Client.Where(x => x.tz == gg.tz).ToList();
//                if (lstShots.Count() == 4)
//                    return "הפציינט עשה כבר 4 חיסונים";
//                else
//                {
//                    int codeShot = lstShots.Count() + 1;
//                    shot4Client sh4cl = new shot4Client(gg.tz, gg.codeShot, gg.shotDate, gg.Id_shot4Client);
//                    db.shot4Client.Add(gg);
//                    db.SaveChanges();
//                    return "נוסף בהצלחה";

//                }


//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        return ex.ToString();

//    }
//}
//[HttpPost]
//[Route("api/Default3/UpdateShot4Client")]
//public string UpdateShot4Client(shot4ClientDTO s)
//{
//    shot4Client gg = new shot4Client(s);

//    try
//    {
//        //            using (var db = new HMO4Covid19_dbEntities())
//        {
//            User user = db.Users.Where(x => x.Email.Equals(obj.username) && x.Password.Equals(obj.password)).FirstOrDefault();
//            return user;
//        }
//    }
//    catch (Exception ex)
//    {
//        return null;
//    }
//}

//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DAL;
using WebApi.DTO;


namespace WebApi.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        private HMO4Covid19_dbEntities db = new HMO4Covid19_dbEntities();
        // Clients Controller
        // GET: api/Default3
        [HttpGet]
        [Route("api/Default3/getClient")]
        public PersonDTO getClient(string tz)
        {
            Person p = db.People.Find(tz);

            if (p == null)
            {
                return null;
            }
            PersonDTO personDTO = new PersonDTO(p);


            return personDTO;

        }
        [HttpGet]
        [Route("api/Default3/getClients")]
        public List<PersonDTO> getClients()
        {
            try
            {
                List<Person> lstClients = new List<Person>();
                List<PersonDTO> lstClientsDTO = new List<PersonDTO>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    lstClients = db.People.ToList();
                }
                foreach (var item in lstClients)
                {
                    lstClientsDTO.Add(new PersonDTO(item));
                }
                return lstClientsDTO;
            }
            catch (Exception ex)
            {
                return null;

            }

        }
        [HttpPost]
        [Route("api/Default3/AddClient")]
        public string AddClient(PersonDTO c)
        {

            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Person client = db.People.FirstOrDefault(x => x.tz == c.tz);//שליםת הלקוח המיועד למחיקה
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
                        Person cl = c.ToPersonDAL(c);
                        //new Person(c.tz, c.firstName, c.lastName, c.postalCode, c.birthDate ?? new DateTime(), c.telephone, c.selphone, c.beIllDate ?? new DateTime(), c.beHealthDate ?? new DateTime());
                        db.People.Add(cl);
                        db.SaveChanges();
                        return "נוסף בהצלחה";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw ex;
            }
        }
        [HttpPost]
        [Route("api/Default3/UpdateClient")]
        public string UpdateClient([FromBody] PersonDTO c)
        {
            try
            {
                Person cl = c.ToPersonDAL(c);
                //Person(c.tz, c.firstName, c.lastName, c.postalCode, c.birthDate ?? new DateTime(), c.telephone, c.selphone, c.beIllDate ?? new DateTime(), c.beHealthDate ?? new DateTime());

                using (var db = new HMO4Covid19_dbEntities())
                {
                    Person client = db.People.FirstOrDefault(x => x.tz == c.tz);//שליםת הלקוח המיועד 
                    if (client != null)
                    {
                        List<Person> cls = db.People.Where(x => x.tz == c.tz).ToList();//שליפת כל החיסונים של הלקוח
                        Person oldCl = client;
                        db.People.Add(cl);
                        db.People.Remove(client);
                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "עודכן בהצלחה";
                    }
                    else
                        return "לא קיים כזה פציינט";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        [HttpGet]
        [Route("api/Default3/DeleteClient")]
        public bool DeleteClient(string tz)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Person client = db.People.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
                    if (client != null)
                    {
                        List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                        {
                            db.shot4Client.Remove(shot);
                        }
                        db.People.Remove(client);//מחיקת הלקוח מהרשימה

                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // /// <summary>
        /// T_Adress controllers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Default3/getAdress")]
        public AdressDTO getAdress(string tz)
        {
            T_Address a = db.T_Address.Find(tz);
            T_Address b = db.T_Address.FirstOrDefault();

            if (a == null)
            {
                return null;
            }
            AdressDTO adressDTO = new AdressDTO(a);


            return adressDTO;

        }
        [HttpPost]
        [Route("api/Default3/AddAdress")]
        public string AddAdress([FromBody] AdressDTO aDTO)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    T_Address a = db.T_Address.FirstOrDefault(x => x.tz == aDTO.tz);
                    if (a != null)
                    {
                        //List<shot4Client> shots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                        //foreach (var shot in shots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                        //{
                        //    db.shot4Client.Remove(shot);
                        //}
                        //db.Client.Remove(client);//מחיקת הלקוח מהרשימה

                        //db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "יש לך כתובת";
                    }
                    else
                    {
                        // T_Address cl = new T_Address(aDTO.tz, aDTO.postalCode, aDTO.numBuild, aDTO.city, aDTO.street);
                        T_Address cl = aDTO.TOAdressDAL(aDTO);
                        db.T_Address.Add(cl);
                        db.SaveChanges();
                        return "נוסף בהצלחה";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw ex;
            }
        }
        [HttpPost]
        [Route("api/Default3/UpdateAdress")]
        public string UpdateAdress([FromBody] AdressDTO aDTO)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    T_Address cl = aDTO.TOAdressDAL(aDTO);
                    //new T_Address(aDTO.tz, aDTO.postalCode, aDTO.numBuild, aDTO.city, aDTO.street);
                    T_Address client = db.T_Address.FirstOrDefault(x => x.tz == aDTO.tz);//שליםת הלקוח המיועד 
                    if (client != null)
                    {
                        List<T_Address> cls = db.T_Address.Where(x => x.tz == aDTO.tz).ToList();//שליפת כל החיסונים של הלקוח
                        T_Address oldCl = client;
                        db.T_Address.Add(cl);
                        db.T_Address.Remove(client);
                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return "עודכן בהצלחה";
                    }
                    else return "לא קיים כזה פציינט";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// shot
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("api/Default3/GetManufactorersByTz")]
        public string GetManufactorersByTz(int codeShot)
        {
            Shot a = db.Shots.Find(codeShot);

            if (a == null)
            {
                return null;
            }
            return a.manufactorer;

        }
        [HttpGet]
        [Route("api/Default3/getShots")]
        public List<ShotDTO> getShots()
        {
            try
            {
                List<Shot> lstShot = new List<Shot>();
                List<ShotDTO> lstShotDTO = new List<ShotDTO>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    lstShot = db.Shots.ToList();
                }
                foreach (var item in lstShot)
                {
                    lstShotDTO.Add(new ShotDTO(item));
                }
                return lstShotDTO;
            }
            catch (Exception ex)
            {
                return null;

            }

        }

        /// <summary>
        /// shot4
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/Default3/GetShots4ByTz")]
        public List<shot4ClientDTO> GetShots4ByTz(string tz)
        {
            try
            {
                List<shot4Client> lstShots = new List<shot4Client>();
                List<shot4ClientDTO> lstShotsDTO = new List<shot4ClientDTO>();

                using (var db = new HMO4Covid19_dbEntities())
                {

                    lstShots = db.shot4Client.Where(x => x.tz == tz).ToList();//שליפת כל החיסונים של הלקוח
                    foreach (var shot in lstShots)//מעבר בלולאה על כלה חיסונים ומחיקה של כל חיסון
                    {
                        lstShotsDTO.Add(new shot4ClientDTO(shot));
                    }

                }
                //return htt
                return lstShotsDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/Default3/AddShot4")]
        public string AddShot4(shot4ClientDTO s)
        {
            shot4Client gg = s.TOshot4ClientDAL(s);
            try
            {
                List<shot4Client> lstShots = new List<shot4Client>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    Person client = db.People.FirstOrDefault(x => x.tz == gg.tz);//שליםת הלקוח המיועד למחיקה
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
                        lstShots = db.shot4Client.Where(x => x.tz == gg.tz).ToList();
                        if (lstShots.Count() == 4)
                            return "הפציינט עשה כבר 4 חיסונים";
                        else
                        {
                            int codeShot = lstShots.Count() + 1;
                            //shot4Client sh4cl = new shot4Client(gg.tz, gg.codeShot,gg.shotDate,gg.Id_shot4Client);
                            db.shot4Client.Add(gg);
                            db.SaveChanges();
                            return "נוסף בהצלחה";

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();

            }
        }
        [HttpPost]
        [Route("api/Default3/UpdateShot4Client")]
        public string UpdateShot4Client(shot4ClientDTO s)
        {
            shot4Client gg = s.TOshot4ClientDAL(s);

            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    // shot4Client cl = new shot4Client(tz, codeShot, shotDate);

                    shot4Client client = db.shot4Client.FirstOrDefault(x => x.tz == gg.tz);//שליםת הלקוח המיועד 
                    if (client != null)
                    {
                        List<shot4Client> cls = db.shot4Client.Where(x => x.tz == gg.tz).ToList();//שליפת כל החיסונים של הלקוח
                        shot4Client oldCl = client;
                        if (cls.Count() == gg.codeShot)
                        {
                            db.shot4Client.Add(gg);
                            db.shot4Client.Remove(client);
                            db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                            return "עודכן בהצלחה";
                        }
                        else if (cls.Count() != gg.codeShot && cls.Count() < 5)
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
                return ex.ToString();
            }
        }
        [HttpGet]
        [Route("api/Default3/DeleteShot4")]
        public bool DeleteShot4(string tz)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    shot4Client shot4 = db.shot4Client.FirstOrDefault(x => x.tz == tz);//שליםת הלקוח המיועד למחיקה
                    if (shot4 != null)
                    {
                        db.shot4Client.Remove(shot4);
                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// LOGIN
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Default3/users/authenticate")]
        public UserDTO authenticate(UP k)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    List<WebApi.DAL.User> users = db.User.Where(x => x.username == k.username).ToList();
                    if (users == null) return null;
                    WebApi.DAL.User user = users.FirstOrDefault(x => x.password == k.password);
                    if (user == null) { return null; }
                    return new WebApi.DTO.UserDTO(user);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        [HttpPost]
        [Route("api/Default3/users/register")]
        public string register(UserDTO user)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {

                    List<WebApi.DAL.User> users = db.User.Where(x => x.username == user.username).ToList();
                    if (users.Count != 0)
                    {
                        WebApi.DAL.User newuser = users.FirstOrDefault(x => x.password == user.password);
                        if (newuser != null) return "יש משתמש כזה";
                    }
                    WebApi.DAL.User cl =
                  user.ToUserDal(user);
                    db.User.Add(cl);
                    db.SaveChanges();
                    return "נוסף בהצלחה";

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw ex;
            }
        }
        [HttpGet]
        [Route("api/Default3/users")]
        public List<UserDTO> getUsers()
        {
            try
            {
                List<User> lstClients = new List<User>();
                List<UserDTO> lstClientsDTO = new List<UserDTO>();
                using (var db = new HMO4Covid19_dbEntities())
                {
                    lstClients = db.User.ToList();
                }
                foreach (var item in lstClients)
                {
                    lstClientsDTO.Add(new UserDTO(item));
                }
                return lstClientsDTO;
            }
            catch (Exception ex)
            {
                return null;

            }

        }
        [HttpDelete]
        [Route("api/Default3/users")]
        public bool DeleteU(int id)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    User u = db.User.FirstOrDefault(x => x.id == id);//שליםת הלקוח המיועד למחיקה
                    if (u != null)
                    {

                        db.User.Remove(u);//מחיקת הלקוח מהרשימה

                        db.SaveChanges();//שמירת השינויים בפועל במסד נתונים
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Default3/users")]
        public UserDTO getUser(int id)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    User u = db.User.FirstOrDefault(x => x.id == id);//שליםת הלקוח המיועד למחיקה

                    if (u != null)
                    {
                        return new UserDTO(u);

                    }
                    else return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("api/Default3/users/Up")]
        public string updadateUser(UserDTO u)
        {
            try
            {
                using (var db = new HMO4Covid19_dbEntities())
                {
                    WebApi.DAL.User oldU = db.User.FirstOrDefault(x => x.id == u.id);
                    if (oldU == null) return "אין משתמש כזה";


                    db.User.Add(u.ToUserDal(u));
                    db.User.Remove(oldU);
                    db.SaveChanges();
                    return "נוסף בהצלחה";

                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw ex;
            }
        }

    }
}