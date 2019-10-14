using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureModel
{
    public class Notification
    {
        public Notification(string title, string content, string timeStamp)
        {
            Title = title;
            Content = content;
            TimeStamp = timeStamp;
        }

        public String Title { get; set; }
        public String Content { get; set; }
        public String TimeStamp { get; set; }
        public static int GetCount() {
            int count=0;

            List<InsureInfo> all = InsureInfo.GetAll();
            foreach(InsureInfo insureInfo in all)
            {

                if (insureInfo.ExpireDate < DateTime.Now)
                {
                    count += 1;
                }
            }

            return count;

        }

        public static List<Notification> GetAll()
        {
            List<Notification> all = new List<Notification>();

            List<InsureInfo> allinfo = InsureInfo.GetAll();

            foreach (InsureInfo insureInfo in allinfo)
            {

                if (insureInfo.ExpireDate < DateTime.Now)
                {
                    String title =insureInfo.Provider +" to be updated";
                    String content = "Expires on " + insureInfo.ExpireDate.ToString() +". Be advised and update soon";
                    String timeStamp = String.Format("{0}:0{1}",DateTime.Now.Hour.ToString(),DateTime.Now.Minute.ToString());
                    Notification temp = new Notification(title, content, timeStamp);
                    all.Add(temp);
                }
            }


            return all;
        }
    }
}
