using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voice_Manager.Models.DataBaseItemsAndLogic;

namespace Voice_Manager.Models
{
    public static class DataBaseLogic
    {

        //Add methods
        //add file item
        public static void AddNewItem(File item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Files.Add(item);
                db.SaveChanges();
            }
        }
        //add site item
        public static void AddNewItem(Site item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Sites.Add(item);
                db.SaveChanges();
            }
        }
        //add answer item
        public static void AddNewItem(Answer item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Answers.Add(item);
                db.SaveChanges();
            }
        }

        //add smart home item
        public static void AddNewItem(Control item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Controls.Add(item);
                db.SaveChanges();
            }
        }


        //Remove methods
        //remove file item
        public static void RemoveItem(File item)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Files.Remove(item);
                db.SaveChanges();
            }
        }
        //remove site item
        public static void RemoveItem(Site item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Sites.Remove(item);
                db.SaveChanges();
            }
        }
        //remove answer item
        public static void RemoveItem(Answer item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Answers.Remove(item);
                db.SaveChanges();
            }
        }
        //remove control item
        public static void RemoveItem(Control item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Controls.Remove(item);
                db.SaveChanges();
            }
        }

        //Update methods
        //update file item
        public static void UpdateItem(File item)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Files.Update(item);
                db.SaveChanges();
            }
        }
        //update site item
        public static void UpdateItem(Site item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Sites.Update(item);
                db.SaveChanges();
            }
        }
        //update answer item
        public static void UpdateItem(Answer item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Answers.Update(item);
                db.SaveChanges();
            }
        }
        //update control item
        public static void UpdateItem(Control item)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Controls.Update(item);
                db.SaveChanges();
            }
        }

        //Get data methods

        public static File[] GetFilesData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var items = db.Files.ToList();
                return items.ToArray();
            }
        }
        public static Site[] GetSitesData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var items = db.Sites.ToList();
                return items.ToArray();
            }
        }

        public static Answer[] GetAnswersData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var items = db.Answers.ToList();
                return items.ToArray();
            }
        }
        public static Control[] GetControlsData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var items = db.Controls.ToList();
                return items.ToArray();
            }
        }


    }
}
