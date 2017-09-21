using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class Class1
    {
        DataClassesDataContext ins = new DataClassesDataContext();
        public void CreateUser(string Fname, string uid, string pass, string email, DateTime join, bool status)
        {


            var abc = ins.Persons.Where(c => c.user_id == uid || c.email == email).ToList();
            Person chck = abc.FirstOrDefault();
            if (chck != null)
            {
                throw new ArgumentException("");
            }
            else
            {

                Person per = new Person();
                per.fullName = Fname;
                per.user_id = uid;
                per.active = status;
                per.email = email;
                per.joined = join;
                per.password = pass;
                ins.Persons.InsertOnSubmit(per);
                ins.SubmitChanges();
            }
        }
        //public void forpass(string email)
        //{
        //    var abc = ins.Persons.Where(c => c.email == email).Select(c => c.password);
        //    MailMessage mm = new MailMessage("sahil.arora333@gmail.com", email);
        //    mm.Subject = "Lost Password";
        //    mm.Body = "Password For your id " + email + " is " + abc;
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.EnableSsl = true;
        //    NetworkCredential login = new NetworkCredential("sahil.arora333@gmail.com", "cutmy#life3");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = login;
        //    smtp.Port = 587;
        //    smtp.Send(mm);

        //}
        public void UpdateProfile(string uid, string Fname, string pass)
        {


            var abc = ins.Persons.Where(c => c.user_id == uid).ToList();
            Person per = abc.FirstOrDefault();
            per.fullName = Fname;
            per.password = pass;
            ins.SubmitChanges();
        }
        public void DeleteProfile(string uid)
        {

            var selper = ins.Persons.Where(c => c.user_id == uid).ToList();
            var selfol = ins.followings.Where(c => c.user_id == uid).ToList();
            var selfol1 = ins.followings.Where(c => c.following_id == uid).ToList();
            var seltweet = ins.tweets.Where(c => c.user_id == uid).ToList();
            Person per = selper.FirstOrDefault();
            ins.followings.DeleteAllOnSubmit(selfol);
            ins.followings.DeleteAllOnSubmit(selfol1);
            ins.tweets.DeleteAllOnSubmit(seltweet);
            ins.Persons.DeleteOnSubmit(per);
            ins.SubmitChanges();
        }
        public Person login(string email, string pass)
        {
            var Fname = ins.Persons.Where(c => c.email == email && c.password == pass).ToList();
            Person per = Fname.FirstOrDefault();
            if (per == null)
            {
                throw new ArgumentException("");
            }
            else
            {
                return per;
            }

        }
        public void AddTweet(string uid, string message, DateTime dt, out int id)
        {
            tweet tw = new tweet();
            tw.message = message;
            tw.user_id = uid;
            tw.created = dt;
            ins.tweets.InsertOnSubmit(tw);
            ins.SubmitChanges();
            id = tw.tweet_id;

        }
        public void DelTweet(int uid)
        {
            var abc = ins.tweets.Where(c => c.tweet_id == uid).ToList();
            tweet tw = abc.FirstOrDefault();
            ins.tweets.DeleteOnSubmit(tw);
            ins.SubmitChanges();

        }
        public void UpdTweet(int uid, string message)
        {
            var abc = ins.tweets.Where(c => c.tweet_id == uid).ToList();
            tweet tw = abc.FirstOrDefault();
            tw.message = message;
            ins.SubmitChanges();
        }
        public void Follow(string uid, string followid)
        {
            following fol = new following();
            fol.user_id = uid;
            fol.following_id = followid;
            ins.followings.InsertOnSubmit(fol);
            ins.SubmitChanges();
        }
        public void UnFollow(string uid, string followid)
        {
            var abc = ins.followings.Where(c => c.user_id == uid && c.following_id == followid).ToList();
            following fol = abc.FirstOrDefault();
            ins.followings.DeleteOnSubmit(fol);
            ins.SubmitChanges();
        }

        public void check(string uid, string followid, out bool chck)
        {
            var abc = ins.followings.Where(c => c.user_id == uid && c.following_id == followid).ToList();
            following fol = abc.FirstOrDefault();
            if (fol == null)
            {
                chck = true;
            }
            else
            {
                chck = false;
            }
        }
        public List<Person> search(string name, string uid)
        {
            if (name == "")
            {
                throw new ArgumentException("Please enter a name");
            }
            List<Person> p = ins.Persons.Where(c => c.fullName.ToUpper().StartsWith(name.ToUpper()) && c.user_id != uid).ToList();
            if (p == null)
            {
                throw new ArgumentException("No user exists");
            }
            else
            {
                return p;
            }
        }
        public void count(string uid, out int a, out int b, out int aa, out int bb)
        {
            ICollection<following> f = ins.followings.Where(c => c.user_id == uid).ToList();
            b = f.Count;
            ICollection<following> fl = ins.followings.Where(c => c.following_id == uid).ToList();
            aa = fl.Count;
            ICollection<tweet> t = ins.tweets.Where(c => c.user_id == uid).ToList();
            a = t.Count;
            var abc = ins.Persons.Where(c => c.user_id == uid).ToList();
            Person p = abc.FirstOrDefault();
            if (p != null)
            {
                bb = (int)p.Imag;
            }
            else
            {
                bb = 0;
            }
        }
        public void imag(string uid)
        {
            var abc = ins.Persons.Where(c => c.user_id == uid).ToList();
            Person p = abc.FirstOrDefault();
            p.Imag = 1;
            ins.SubmitChanges();
        }

        public List<tweet> Display(string uid)
        {
            List<tweet> p = ins.tweets.Where(c => c.user_id == uid).ToList();
            return p;
        }
        public List<Person> following(string uid)
        {

            var fol = (from pr in ins.Persons
                       from f in ins.followings
                       where f.user_id == uid
                       where f.following_id == pr.user_id
                       select pr).ToList();
            return fol;
        }
        public List<Person> followers(string uid)
        {
            var fol = (from pr in ins.Persons
                       from f in ins.followings
                       where f.following_id == uid
                       where f.user_id == pr.user_id
                       select pr).ToList();
            return fol;
        }
        public List<Person> users(string uid)
        {
            List<Person> user = ins.Persons.Where(c => c.user_id != uid).ToList();
            return user;
        }
       
        public int checkUser(string uid, string followid)
        {
            int chk;
            var abc = ins.followings.Where(c => c.user_id == uid && c.following_id == followid).ToList();
            following fol = abc.FirstOrDefault();
            if (fol == null)
            {
                chk = 0;
            }
            else
            {
                chk = 1;
            }
            return chk;
        }
        public List<tweet> Displaytweets(string uid)
        {
            {
                var twt = (from f1 in ins.followings
                           from t in ins.tweets
                           where f1.user_id == uid
                           where f1.following_id == t.user_id
                           select t).ToList();
                return twt;
            }

        }
    }
}
